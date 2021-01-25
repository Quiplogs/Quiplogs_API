using Api.Presenters;
using Api.Serialization;
using Quiplogs.Assets.Dto.Responses.AssetUsage;
using System.Net;
using Quiplogs.Core.Interfaces;

namespace Api.UseCases.AssetUsage.Get
{
    public class GetAssetUsagePresenter : IOutputPort<GetAssetUsageResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GetAssetUsagePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetAssetUsageResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.AssetUsage) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
