using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Core.Domain;
using Api.Core.Dto.Requests.Equipment;
using Api.Core.Interfaces.UseCases.Equipment;
using Api.Presenters;
using Api.Presenters.Equipment;
using Api.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IFetchEquipmentUseCase _fetchEquipmentUseCase;
        private readonly FetchEquipmentPresenter _fetchEquipmentPresenter;

        public EquipmentController(IFetchEquipmentUseCase fetchEquipmentUseCase, FetchEquipmentPresenter fetchEquipmentPresenter)
        {
            _fetchEquipmentUseCase = fetchEquipmentUseCase;
            _fetchEquipmentPresenter = fetchEquipmentPresenter;
        }

        //GET: api/Equipment
        [HttpPost]
        public async Task<ActionResult> Get([FromBody] Models.Requests.Equipment.FetchEquipmentRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _fetchEquipmentUseCase.Handle(new FetchEquipmentRequest(request.CompanyId, request.LocationId, request.PageNumber), _fetchEquipmentPresenter);
            return _fetchEquipmentPresenter.ContentResult;
        }
    }
}
