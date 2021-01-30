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
    public class PutUseCase<T1, T2> : IPutUseCase<T1, T2>
        where T1 : BaseEntity
        where T2 : BaseEntityDto
    {
        private readonly IBaseRepository<T1, T2> _repository;

        public PutUseCase(IBaseRepository<T1, T2> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(PutRequest<T1> request, IOutputPort<PutResponse<T1>> outputPort)
        {
            var response = await _repository.Put(request.Model);
            if (response.Success)
            {
                outputPort.Handle(new PutResponse<T1>(response.Model, true));
                return true;
            }

            outputPort.Handle(new PutResponse<T1>(new[] { new Error("", "Model not Found.") }));
            return false;
        }
    }
}
