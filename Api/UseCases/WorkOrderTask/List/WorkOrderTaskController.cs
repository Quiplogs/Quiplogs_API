﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrderTask;

namespace Api.UseCases.WorkOrderTask.List
{
    public class WorkOrderTaskController : BaseApiController
    {
        private readonly IListWorkOrderTaskUseCase _listWorkOrderTaskUseCase;
        private readonly ListWorkOrderTaskPresenter _listWorkOrderTaskPresenter;

        public WorkOrderTaskController(IListWorkOrderTaskUseCase listWorkOrderTaskUseCase, ListWorkOrderTaskPresenter listWorkOrderTaskPresenter)
        {
            _listWorkOrderTaskUseCase = listWorkOrderTaskUseCase;
            _listWorkOrderTaskPresenter = listWorkOrderTaskPresenter;
        }

        [HttpGet("List")]
        public async Task<ActionResult> List([FromQuery] ListWorkOrderTaskRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var companyId = request.CompanyId;
            if (string.IsNullOrEmpty(companyId))
            {
                companyId = this.GetCompanyId();
            }

            await _listWorkOrderTaskUseCase.Handle(new Quiplogs.WorkOrder.Dto.Requests.WorkOrderTask.ListWorkOrderTaskRequest(request.WordOrderId, request.PageNumber), _listWorkOrderTaskPresenter);
            return _listWorkOrderTaskPresenter.ContentResult;
        }
    }
}