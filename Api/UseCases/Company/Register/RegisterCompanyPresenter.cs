using Api.Presenters;
using Api.Serialization;
using System.Net;
using Quiplogs.Core.Dto.Responses.Company;
using Quiplogs.Core.Interfaces;

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
