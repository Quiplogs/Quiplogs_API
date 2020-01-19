namespace Api.Core.Dto
{
    public class Pager
    {
        public int TotalItems { get; }

        public int CurrentPage { get; }

        public int PageSize { get; }

        public decimal TotalPages { get; }

        public int StartPage { get; }

        public int EndPage { get; }

        public int StartIndex { get; }

        public int EndIndex { get; }

        public int[] Pages { get; }

        public Pager(int totalItems, int currentPage, int pageSize, decimal totalPages, int startPage, int endPage, int startIndex, int endIndex, int[] pages)
        {
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
            StartIndex = startIndex;
            EndIndex = endIndex;
            Pages = pages;
        }
    }
}
