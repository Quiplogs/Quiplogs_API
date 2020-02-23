using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.Assets.Dto.Responses.Asset;
using System.Net;

namespace Api.UseCases.Asset.Get
{
    public class GetAssetPresenter : IOutputPort<GetAssetResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GetAssetPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetAssetResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Asset) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
