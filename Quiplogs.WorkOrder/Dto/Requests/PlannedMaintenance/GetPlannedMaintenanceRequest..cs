using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;

public class GetPlannedMaintenanceRequest : IRequest<GetPlannedMaintenanceResponse>
{
    public string Id { get; }
    public GetPlannedMaintenanceRequest(string id)
    {
        Id = id;
    }
}
