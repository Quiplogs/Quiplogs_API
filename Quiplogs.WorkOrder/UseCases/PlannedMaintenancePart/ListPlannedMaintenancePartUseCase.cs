using System.Threading.Tasks;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenancePart;

namespace Quiplogs.WorkOrder.UseCases.PlannedMaintenancePart
{
    //public class ListPlannedMaintenancePartUseCase : IListPlannedMaintenancePartUseCase
    //{
    //    private readonly IPlannedMaintenancePartRepository _repository;

    //    public ListPlannedMaintenancePartUseCase(IPlannedMaintenancePartRepository repository)
    //    {
    //        _repository = repository;
    //    }

    //    public async Task<bool> Handle(ListPlannedMaintenancePartRequest message, IOutputPort<ListPlannedMaintenancePartResponse> outputPort)
    //    {
    //        var response = await _repository.List(message.PlannedMaintenanceId);

    //        if (response.Success)
    //        { 
    //            outputPort.Handle(new ListPlannedMaintenancePartResponse(response.PlannedMaintenanceParts, true));
    //            return true;
    //        }

    //        outputPort.Handle(new ListPlannedMaintenancePartResponse(new[] { new Error("", "No Planned Maintenances Parts Found.") }));
    //        return false;
    //    }
    //}
}
