using Api.Core.Dto.Responses.Company;
using Api.Core.Interfaces;
using Api.Presenters;
using Api.Serialization;
using System.Net;

namespace Api.UseCases.Company.Register
{
    public sealed class RegisterCompanyPresenter : IOutputPort<RegisterCompanyResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RegisterCompanyPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RegisterCompanyResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
