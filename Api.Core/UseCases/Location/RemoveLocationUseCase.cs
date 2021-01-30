using System.Threading.Tasks;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Location;
using Quiplogs.Core.Dto.Responses.Location;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Location;

namespace Quiplogs.Core.UseCases.Location
{
    //public class RemoveLocationUseCase : IRemoveLocationUseCase
    //{
    //    private readonly ILocationRepository _repository;

    //    public RemoveLocationUseCase(ILocationRepository repository)
    //    {
    //        _repository = repository;
    //    }

    //    public async Task<bool> Handle(RemoveLocationRequest message, IOutputPort<RemoveLocationResponse> outputPort)
    //    {
    //        var response = await _repository.Remove(message.Id);
    //        if (response.Success)
    //        {
    //            outputPort.Handle(new RemoveLocationResponse(response.Description, true));
    //            return true;
    //        }

    //        outputPort.Handle(new RemoveLocationResponse(new[] { new Error("", "Error removing Location.") }));
    //        return false;
    //    }
    //}
}
