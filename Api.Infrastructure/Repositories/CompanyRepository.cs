using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Dto.Repositories;
using Api.Core.Interfaces.Repositories;
using Api.Infrastructure.SqlContext;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Quiplogs.Core.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IMapper _mapper;
        private readonly SqlDbContext _context;

        public CompanyRepository(UserManager<UserEntity> userManager, IMapper mapper, SqlDbContext context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<CreateCompanyResponse> Create(Company company, string password)
        {
            var companyMapped = _mapper.Map<CompanyDto>(company);

            _context.Add(companyMapped);
            _context.SaveChanges();

            var identityResult = await _userManager.AddPasswordAsync(companyMapped.Users.FirstOrDefault(), password);
            return new CreateCompanyResponse(companyMapped.Id, identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }
    }
}
