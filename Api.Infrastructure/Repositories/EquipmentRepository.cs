using Api.Core.Domain.Entities;
using Api.Core.Dto.Repositories;
using Api.Core.Interfaces.Repositories;
using Api.Infrastructure.SqlContext;
using AutoMapper;
using System.Threading.Tasks;

namespace Api.Infrastructure.Repositories
{
    public class EquipmentRepository// : IEquipmentRepository
    {
        //private readonly SqlDbContext _context;

        //public EquipmentRepository(IMapper mapper, SqlDbContext context)
        //{
        //    _context = context;
        //}
        //public async Task<PagedResultsResponse<Equipment>> GetPagedResults(int pageNumber)
        //{
        //    var companyMapped = _mapper.Map<CompanyEntity>(company);

        //    _context.Add(companyMapped);
        //    _context.SaveChanges();

        //    var identityResult = await _userManager.AddPasswordAsync(companyMapped.Users.FirstOrDefault(), password);
        //    return new CreateCompanyResponse(companyMapped.Id, identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        //}
    }
}
