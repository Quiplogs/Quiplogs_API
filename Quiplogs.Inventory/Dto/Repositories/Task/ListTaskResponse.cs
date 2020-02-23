using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.Inventory.Dto.Repositories.Task
{
    public class ListTaskResponse : BaseResponse
    {
        public List<Domain.Entities.TaskEntity> Tasks { get; set; }

        public ListTaskResponse(List<Domain.Entities.TaskEntity> tasks, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Tasks = tasks;
        }
    }
}
