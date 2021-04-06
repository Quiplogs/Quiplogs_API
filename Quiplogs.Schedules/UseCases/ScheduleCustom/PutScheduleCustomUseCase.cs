using System;
using Quiplogs.Core.Dto;
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
            var lapsedCycles = Math.Round(model.StartingAt / model.RecurEvery, 0);

            if (lapsedCycles == 0 || lapsedCycles % 10 == 0)
            {
                return model.StartingAt + model.RecurEvery;
            }

            var overLastCycleDue = (lapsedCycles * model.RecurEvery) - model.StartingAt;

            return model.StartingAt + overLastCycleDue;
        }
    }
}
