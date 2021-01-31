using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using System.Threading.Tasks;

namespace Quiplogs.Core.UseCases.Generic
{
    public class RemoveUseCase<T1, T2> : IRemoveUseCase<T1, T2>
        where T1 : BaseEntity
        where T2 : BaseEntityDto
    {
        private readonly IBaseRepository<T1, T2> _repository;

        public RemoveUseCase(IBaseRepository<T1, T2> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemoveRequest request, IOutputPort<RemoveResponse> outputPort)
        {
            await _repository.Remove(request.Id);

            outputPort.Handle(new RemoveResponse("Removed Successfully", true));
            return true;
        }
    }
}
