using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.Assets.Dto.Responses.Asset;
using System.Net;

namespace Api.UseCases.Asset.Remove
{
    public class RemoveAssetPresenter : IOutputPort<RemoveAssetResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RemoveAssetPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RemoveAssetResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Description) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
