namespace Quiplogs.Core.Domain
{
    public class Pager
    {
        public int TotalItems { get; }

        public int CurrentPage { get; }

        public int PageSize { get; }

        public double TotalPages { get; }

        public int StartIndex { get; }

        public int EndIndex { get; }

        public int[] Pages { get; }

        public Pager(int totalItems, int currentPage, int pageSize, double totalPages, int startIndex, int endIndex, int[] pages)
        {
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartIndex = startIndex;
            EndIndex = endIndex;
            Pages = pages;
        }
    }
}
