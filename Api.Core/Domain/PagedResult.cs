using System;
using System.Collections.Generic;

namespace Api.Core.Domain.Entities
{
    public class PagedResult<T>
    {
        public Pager Pager { get; set; }

        public List<T> PagedItems { get; set; }

        /// <summary>
        /// Gets a Paged List Result as needed by the Angular Pager
        /// </summary>
        /// <param name="items">List of Items where Skip() and Take() has already been applied</param>
        /// <param name="totalItems">Total number of items in the DB</param>
        /// <param name="currentPage">Current pager from the pager</param>
        public PagedResult(List<T> items, int totalItems, int currentPage, int pageSize)
        {
            var totalPages = Math.Ceiling((double)totalItems / pageSize);
            var startIndex = (currentPage * pageSize) - pageSize;
            var endIndex = (currentPage * pageSize) - 1;

            //Keep the pager to only show 3 pages at a time e.g. << < 1 2 3 > >>
            int[] pages = new int[] { currentPage - 1, currentPage, currentPage + 1 };
            if (currentPage == 1)
            {
                pages = new int[] { 1 };
                if (totalPages == 2)
                {
                    pages = new int[] { 1, 2 };
                }
                if(totalPages > 2)
                {
                    pages = new int[] { 1, 2, 3 };
                }
            }

            if(currentPage == totalPages)
            {
                pages = new int[] { currentPage - 2, currentPage - 1, currentPage };
            }

            Pager = new Pager(totalItems, currentPage, pageSize, totalPages, startIndex, endIndex, pages);
            PagedItems = items;
        }
    }
}
