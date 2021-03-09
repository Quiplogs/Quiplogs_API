using Api.Extensions;
using Api.Helpers;
using Api.Presenters;
using Api.Services;
using Api.Services.Interfaces;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Quiplogs.Assets;
using Quiplogs.Assets.Data.Mapping;
using Quiplogs.BlobStorage;
using Quiplogs.Core;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Data.Mapping;
using Quiplogs.Dashboard;
using Quiplogs.Infrastructure;
using Quiplogs.Infrastructure.Auth;
using Quiplogs.Infrastructure.SqlContext;
using Quiplogs.Inventory;
using Quiplogs.Inventory.Data.Mapping;
using Quiplogs.Notifications.Send;
using Quiplogs.WorkOrder;
using Quiplogs.WorkOrder.Data.Mapping;
using System;
using System.Net;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.HttpOverrides;
using Quiplogs.PlannedMaintenance;
using Quiplogs.PlannedMaintenance.Data.Mapping;
using Quiplogs.Schedules.Data.Mapping;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add Services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Entity framework Core.
            services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("Api.Infrastructure")));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            services.AddControllers()
                .AddNewtonsoftJson();

            //Redis cache
            var redisSettingsSection = Configuration.GetSection("RedisSettings");
            var redisSettings = redisSettingsSection.Get<RedisSettings>();

            //services.AddDistributedMemoryCache();
            //services.AddStackExchangeRedisCache(options =>
            //{
            //    options.ConfigurationOptions = new ConfigurationOptions
            //    {
            //        AllowAdmin = redisSettings.AllowAdmin,
            //        Ssl = redisSettings.Ssl,
            //        ConnectTimeout = redisSettings.ConnectTimeout,
            //        ConnectRetry = redisSettings.ConnectRetry,
            //        DefaultDatabase = redisSettings.Database,
            //        EndPoints = { { redisSettings.Host, redisSettings.Port } }
            //    };
            //});

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            // add identity
            var identityBuilder = services.AddIdentityCore<UserEntity>(o =>
            {
                // configure identity options
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            });

            identityBuilder = new IdentityBuilder(identityBuilder.UserType, typeof(IdentityRole<Guid>), identityBuilder.Services);
            identityBuilder
                .AddEntityFrameworkStores<SqlDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CoreProfile());
                mc.AddProfile(new InventoryProfile());
                mc.AddProfile(new WorkOrderProfile());
                mc.AddProfile(new AssetProfile());
                mc.AddProfile(new PlannedMaintenanceProfile());
                mc.AddProfile(new ScheduleProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddAutoMapper(typeof(Startup));
            services.AddApiVersioning();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Version = "V1",
                Title = "Quiplogs V1 API",
                Description = "Quiplogs API"
            }));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new CoreModule());
            builder.RegisterModule(new BlobStorageModule());
            builder.RegisterModule(new InfrastructureModule());            
            builder.RegisterModule(new AssetsModule());
            builder.RegisterModule(new InventoryModule());
            builder.RegisterModule(new WorkOrderModule());
            builder.RegisterModule(new DashboardModule());
            builder.RegisterModule(new PlannedMaintenanceModule());

            builder.RegisterModule(new SendNotificationModule(Configuration));

            // Presenters
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Presenter")).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(GetPresenter<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GetService<,>)).As(typeof(IGetService<,>)).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(PutPresenter<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(PutService<,>)).As(typeof(IPutService<,>)).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(PagedListPresenter<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(PagedListService<,>)).As(typeof(IPagedListService<,>)).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(ListPresenter<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(ListService<,>)).As(typeof(IListService<,>)).InstancePerLifetimeScope();

            builder.RegisterType<RemovePresenter>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(RemoveService<,>)).As(typeof(IRemoveService<,>)).InstancePerLifetimeScope();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IHostApplicationLifetime lifetime, IDistributedCache cache)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            lifetime.ApplicationStarted.Register(() =>
            {
                var currentTimeUtc = DateTime.UtcNow.ToString();
                byte[] encodedCurrentTimeUtc = Encoding.UTF8.GetBytes(currentTimeUtc);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(20));
                cache.Set("cachedTimeUTC", encodedCurrentTimeUtc, options);
            });

            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            //app.UseHttpsRedirection();
            app.UseRouting();

            app.UseExceptionHandler(
                builder =>
                {
                    builder.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                            var error = context.Features.Get<IExceptionHandlerFeature>();
                            if (error != null)
                            {
                                context.Response.AddApplicationError(error.Error.Message);
                                await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                            }
                        });
                });

            // global cors policy
            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Quiplogs API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
