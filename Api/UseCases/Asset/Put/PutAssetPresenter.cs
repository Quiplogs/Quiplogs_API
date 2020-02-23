using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using Quiplogs.Assets.Dto.Responses.Asset;
using System.Net;

namespace Api.UseCases.Asset.Put
{
    public class PutAssetPresenter : IOutputPort<PutAssetResponse>
    {
        public JsonContentResult ContentResult { get; }

        public PutAssetPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(PutAssetResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Asset) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
