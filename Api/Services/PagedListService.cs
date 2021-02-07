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
    public class PagedListService<T1, T2> : IPagedListService<T1, T2>
        where T1 : BaseEntity
        where T2 : BaseEntityDto
    {
        private readonly IPagedListUseCase<T1, T2> _pagedListUseCase;
        private readonly PagedListPresenter<T1> _pagedListPresenter;

        public PagedListService(IPagedListUseCase<T1, T2> pagedListUseCase, PagedListPresenter<T1> pagedListPresenter)
        {
            _pagedListUseCase = pagedListUseCase;
            _pagedListPresenter = pagedListPresenter;
        }

        public async Task<JsonContentResult> PagedList(PagedListRequest request, Guid companyId)
        {
            await _pagedListUseCase.Handle(new PagedRequest<T1>(companyId, request.LocationId, request.ParentId, request.PageNumber, request.PageSize, request.FilterParameters), _pagedListPresenter);
            return _pagedListPresenter.ContentResult;
        }
    }
}
