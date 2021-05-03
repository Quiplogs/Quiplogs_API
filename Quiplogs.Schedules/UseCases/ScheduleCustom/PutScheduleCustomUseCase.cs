using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.Schedules.Data.Entities;
using System.Threading.Tasks;

namespace Quiplogs.Schedules.UseCases.ScheduleCustom
{
    public class PutScheduleCustomUseCase : IPutUseCase<Domain.Entities.ScheduleCustom, ScheduleCustomDto>
    {
        private readonly IBaseRepository<Domain.Entities.ScheduleCustom, ScheduleCustomDto> _baseRepository;

        public PutScheduleCustomUseCase(IBaseRepository<Domain.Entities.ScheduleCustom, ScheduleCustomDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(PutRequest<Domain.Entities.ScheduleCustom> request, IOutputPort<PutResponse<Domain.Entities.ScheduleCustom>> outputPort)
        {
            request.Model.CycleNextDue = CalculcateWhenToProcessNext(request.Model);

            var response = await _baseRepository.Put(request.Model);

            if (response.Success)
            {
                outputPort.Handle(new PutResponse<Domain.Entities.ScheduleCustom>(response.Model, true));
                return true;
            }

            outputPort.Handle(new PutResponse<Domain.Entities.ScheduleCustom>(response.Errors));
            return false;
        }

        private decimal? CalculcateWhenToProcessNext(Domain.Entities.ScheduleCustom model)
        {
            return model.StartingAt + model.RecurEvery;
        }
    }
}
