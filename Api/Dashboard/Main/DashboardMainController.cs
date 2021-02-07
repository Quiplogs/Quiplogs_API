using Api.UseCases;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Dashboard;

namespace Api.Dashboard.Main
{
    public class DashboardMainController : BaseApiController
    {
        private readonly IDashboardRepository _repo;

        public DashboardMainController(IDashboardRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult TotalAssets([FromQuery] DashboardMainRequest request)
        {
            if (!ModelState.IsValid)
            { 
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var analyticsRequest = new AnalyticsRequest
            {
                CompanyId = GetCompanyId(request.CompanyId),
                LocationId = request.LocationId,
                StoredProcedure = request.QueryName
            };

            var data = _repo.GetDashboardData(analyticsRequest);
            return new JsonResult(data);
        }
    }
}
