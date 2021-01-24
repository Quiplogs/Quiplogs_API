using System.Threading.Tasks;
using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;

namespace Quiplogs.Core.UseCases.Generic
{
    public class GetUseCase<T1, T2> : IGetUseCase<T1> 
        where T1 : BaseEntity
        where T2 : BaseEntityDto
    {
        private readonly IBaseRepository<T1, T2> _repository;

        public GetUseCase(IBaseRepository<T1, T2> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(GetRequest<T1> request, IOutputPort<GetResponse<T1>> outputPort)
        {
            var response = await _repository.GetById(request.Id);
            if (response.Success)
            {
                outputPort.Handle(new GetResponse<T1>(response.Model, true));
                return true;
            }

            outputPort.Handle(new GetResponse<T1>(new[] { new Error("", "Model not Found.") }));
            return false;
        }
    }
}
