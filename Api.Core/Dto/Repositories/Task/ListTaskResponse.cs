using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.Task
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
