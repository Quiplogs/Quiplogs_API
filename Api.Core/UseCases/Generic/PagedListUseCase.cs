using System.Threading.Tasks;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;

namespace Quiplogs.Core.UseCases.Generic
{
    public class PagedListUseCase<T1, T2> : IPagedListUseCase<T1, T2>
        where T1 : BaseEntity
        where T2 : BaseEntityDto
    {
        private readonly IBaseRepository<T1, T2> _baseRepository;

        public PagedListUseCase(IBaseRepository<T1, T2> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(PagedRequest<T1> request, IOutputPort<PagedResponse<T1>> outputPort)
        {
            var response = await _baseRepository.PagedList(request.CompanyId, request.PageNumber, request.PageSize, request.FilterParameters,
                predicate: model => model.CompanyId == request.CompanyId);
            if (response.Success)
            {
                outputPort.Handle(new PagedResponse<T1>(response.PagedResult, true));
                return true;
            }

            outputPort.Handle(new PagedResponse<T1>(new[] { new Error("", "Models not Found.") }));
            return false;
        }
    }
}
