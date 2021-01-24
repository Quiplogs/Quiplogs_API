using System.Threading.Tasks;
using Api.Core.Interfaces.UseCases.User;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Notifications.Send.Interfaces;

namespace Api.UseCases.User.Get
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGetUserUseCase _getUserUseCase;
        private readonly GetUserPresenter _getUserPresenter;
        private readonly ISendService _sendService;

        public UserController(IGetUserUseCase getUserUseCase, GetUserPresenter getUserPresenter, ISendService sendService)
        {
            _getUserUseCase = getUserUseCase;
            _getUserPresenter = getUserPresenter;
            _sendService = sendService;
        }


        [HttpGet("Get")]
        public async Task<ActionResult> Get([FromQuery] GetUserRequest request)
        {
            //var tags = new Dictionary<string, string>();
            //tags.Add("firstName", "Jonathan");

            //var mail = new EmailWithTemplate
            //{
            //    TemplateId = "12345667",
            //    FromEmailAddress = "test@from.com",
            //    FromName = "Busy Dev",
            //    ToEmailAddress = "test.to.com",
            //    ToName = "Another Busy Dev",
            //    ReplacementTags = tags
            //};

            //await _sendService.SendNotification(mail);

            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _getUserUseCase.Handle(new Core.Dto.Requests.User.GetUserRequest(request.Id), _getUserPresenter);
            return _getUserPresenter.ContentResult;
        }
    }
}