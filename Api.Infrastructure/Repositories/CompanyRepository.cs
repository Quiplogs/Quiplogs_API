using Api.Core;
using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Dto.Repositories;
using Api.Core.Helpers;
using Api.Core.Interfaces.Repositories;
using Api.Infrastructure.SqlContext;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Quiplogs.Core.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IMapper _mapper;
        private readonly SqlDbContext _context;
        private ICaching _cache;

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
                var existingModel = _context.Companies.Find(model.Id);
                var mappedModel = _mapper.Map<CompanyDto>(model);

                if (existingModel == null)
                {
                    _context.Companies.Add(mappedModel);                    
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
                return new CreateCompanyResponse(null, false, new[] { new Error(GlobalVariables.error_locationFailure, $"Error updating Company. {ex.Message}") });
            }
        }

        public async Task<int> GetTotalRecords()
        {
            var _cacheKey = $"Companies-total";
            var cachedTotal = await _cache.GetAsnyc<int>(_cacheKey);

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
