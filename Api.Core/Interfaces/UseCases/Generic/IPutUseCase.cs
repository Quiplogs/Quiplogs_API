using System;
using System.Collections.Generic;
using System.Text;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;

namespace Quiplogs.Core.Interfaces.UseCases.Generic
{
    public interface IPutUseCase<T1, T2> : IRequestHandler<PutRequest<T1>, PutResponse<T1>> where T1 : BaseEntity
    {
    }
}
