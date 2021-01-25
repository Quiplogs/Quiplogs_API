using System.Net;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.Assets.Dto.Responses.Asset;
using Quiplogs.Core.Interfaces;

namespace Api.UseCases.Asset.List
{ 
    public class FetchAssetPresenter : IOutputPort<FetchAssetResponse>
    {
        public JsonContentResult ContentResult { get; }

        public FetchAssetPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(FetchAssetResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.PagedResult) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
