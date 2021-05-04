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
    public class TechnicianListUseCase<T1, T2> : IListUseCase<T1, T2>
        where T1 : BaseEntity
        where T2 : BaseEntityDto
    {
        private readonly IBaseRepository<T1, T2> _repository;

        public TechnicianListUseCase(IBaseRepository<T1, T2> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ListRequest<T1> request, IOutputPort<ListResponse<T1>> outputPort)
        {
            var response = await _repository.List(request.CompanyId, model => model.CompanyId == request.CompanyId, null, null);
            if (response.Success)
            {
                outputPort.Handle(new ListResponse<T1>(response.Models, true));
                return true;
            }

            outputPort.Handle(new ListResponse<T1>(new[] { new Error("", "Model not Found.") }));
            return false;
        }
    }
}
