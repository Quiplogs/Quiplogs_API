using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Api.UseCases
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        internal Guid GetCompanyId(Guid? companyId)
        {
            if (companyId != null && companyId != Guid.Empty)
                return companyId.Value;
            else
                return Guid.Parse(User.FindFirstValue("comId"));
        }
    }
}