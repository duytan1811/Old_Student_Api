namespace STM.API.Requests.Base
{
    using STM.Common.Constants;

    public class BaseSearchRequest<T>
        where T : class
    {
        public BaseSearchRequest()
        {
            this.Paginator = new Paginator();
            this.Sorting = new Sorting();
        }

        public Paginator Paginator { get; set; }

        public Sorting Sorting { get; set; }

        public T SearchParams { get; set; }

        public int Start
        {
            get
            {
                return this.Paginator.Page == 0 ? 0 : (this.Paginator.Page - 1) * this.Paginator.PageSize;
            }
        }

        public int Length => this.Paginator.PageSize;
    }

    public class Paginator
    {
        public int Page { get; set; }

        public int PageSize { get; set; } = 10;

        public int Total { get; set; }
    }

    public class Sorting
    {
        public string Column { get; set; } = ColumnNames.CreatedAt;

        public string Direction { get; set; } = "desc";
    }
}
