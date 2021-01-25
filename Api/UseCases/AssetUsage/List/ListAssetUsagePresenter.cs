using Api.Presenters;
using Api.Serialization;
using Quiplogs.Assets.Dto.Responses.AssetUsage;
using System.Net;
using Quiplogs.Core.Interfaces;

namespace Api.UseCases.AssetUsage.List
{
    public class ListAssetUsagePresenter : IOutputPort<ListAssetUsageResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ListAssetUsagePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(ListAssetUsageResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.PagedResult) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
