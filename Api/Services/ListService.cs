using System;
using System.Threading.Tasks;
using Api.Presenters;
using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Interfaces.UseCases.Generic;

namespace Api.Services
{
    public class ListService<T1, T2> : IListService<T1, T2>
        where T1 : BaseEntity
        where T2 : BaseEntityDto
    {
        private readonly IListUseCase<T1, T2> _listUseCase;
        private readonly ListPresenter<T1> _listPresenter;

        public ListService(IListUseCase<T1, T2> listUseCase, ListPresenter<T1> listPresenter)
        {
            _listUseCase = listUseCase;
            _listPresenter = listPresenter;
        }

        public async Task<JsonContentResult> List(ListRequest request, Guid companyId)
        {
            await _listUseCase.Handle(new ListRequest<T1>(companyId, request.LocationId, request.ParentId, request.FilterParameters), _listPresenter);
            return _listPresenter.ContentResult;
        }
    }
}
