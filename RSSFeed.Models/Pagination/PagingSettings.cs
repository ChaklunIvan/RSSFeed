namespace RSSFeed.Models.Pagination
{
    public class PagingSettings
    {
        private const int maxPageSize = 50;
        public int CurrentPage { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize 
        { 
            get { return _pageSize; }
            set { _pageSize = value > maxPageSize ? maxPageSize : value; }
        }
    }
}
