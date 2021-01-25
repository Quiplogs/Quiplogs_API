using Api.Presenters;
using Api.Serialization;
using Quiplogs.Assets.Dto.Responses.AssetUsage;
using System.Net;
using Quiplogs.Core.Interfaces;

namespace Api.UseCases.AssetUsage.Put
{
    public class PutAssetUsagePresenter : IOutputPort<PutAssetUsageResponse>
    {
        public JsonContentResult ContentResult { get; }

        public PutAssetUsagePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(PutAssetUsageResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.AssetUsage) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
