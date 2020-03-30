using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Data.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.UseCases
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        internal string GetCompanyId()
        {
            return User.FindFirstValue("comId");
        }
    }
}