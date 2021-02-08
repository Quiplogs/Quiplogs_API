using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.UseCases.User;
using System.Threading.Tasks;

namespace Api.UseCases.User.TechnicianList
{
    public class UserController : BaseApiController
    {
        private readonly TechnicianListUseCase _listUseCase;
        private readonly ListPresenter<AppUser> _listPresenter;

        public UserController(TechnicianListUseCase listUseCase, ListPresenter<AppUser> listPresenter)
        {
            _listUseCase = listUseCase;
            _listPresenter = listPresenter;
        }

        [HttpPost("TechnicianList")]
        public async Task<ActionResult> List([FromBody] ListRequest request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _listUseCase.Handle(new ListRequest<AppUser>(GetCompanyId(request.CompanyId), request.LocationId, request.ParentId, request.FilterParameters), _listPresenter);
            return _listPresenter.ContentResult;
        }
    }
}
