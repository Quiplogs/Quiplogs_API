using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace Api.UseCases
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        internal Guid GetCompanyId(Guid? companyId) =>  companyId ?? Guid.Parse(User.FindFirstValue("comId"));
    }
}