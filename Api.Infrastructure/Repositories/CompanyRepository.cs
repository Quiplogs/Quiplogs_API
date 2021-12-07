using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;
using Quiplogs.Core.Helpers;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Infrastructure.SqlContext;

namespace Quiplogs.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IMapper _mapper;
        private readonly SqlDbContext _context;
        private readonly ICaching _cache;

        public CompanyRepository(IMapper mapper, SqlDbContext context, ICaching cache)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
        }

        public async Task<CreateCompanyResponse> Put(Company model)
        {
            try
            {
                var existingModel = await _context.Companies.FindAsync(model.Id);
                var mappedModel = _mapper.Map<CompanyDto>(model);

                if (existingModel == null)
                {
                    await _context.Companies.AddAsync(mappedModel);                    
                }
                else
                {
                    _context.Entry(existingModel).CurrentValues.SetValues(mappedModel);
                }

                await _context.SaveChangesAsync();
                await UpdateTotalItems();

                Company mappedCompany = _mapper.Map<Company>(mappedModel);
                return new CreateCompanyResponse(mappedModel.Id, true, null);
            }
            catch (SqlException ex)
            {
                return new CreateCompanyResponse(new System.Guid(), false, new[] { new Error("", $"Error updating Company. {ex.Message}") });
            }
        }

        public async Task<int> GetTotalRecords()
        {
            var cacheKey = $"Companies-total";
            var cachedTotal = await _cache.GetAsnyc<int>(cacheKey);

            if (cachedTotal == 0)
            {
                await UpdateTotalItems();
            }

            return cachedTotal;
        }

        private async Task UpdateTotalItems()
        {
            await _cache.SetAsnyc($"Companies-total", _context.Companies.Count());
        }
    }
}
