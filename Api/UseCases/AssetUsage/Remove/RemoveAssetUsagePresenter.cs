using Api.Presenters;
using Api.Serialization;
using Quiplogs.Assets.Dto.Responses.AssetUsage;
using System.Net;
using Quiplogs.Core.Interfaces;

namespace Api.UseCases.AssetUsage.Remove
{
    public class RemoveAssetUsagePresenter : IOutputPort<RemoveAssetUsageResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RemoveAssetUsagePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RemoveAssetUsageResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Description) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
