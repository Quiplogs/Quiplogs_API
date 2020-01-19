using System.Collections.Generic;

namespace Api.Core.Dto
{
    public class PagedResult<T>
    {
        public Pager Pager { get; set; }

        public List<T> PageOfItems { get; set; }
    }
}
