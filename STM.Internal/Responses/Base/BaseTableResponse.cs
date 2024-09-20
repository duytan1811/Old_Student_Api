namespace STM.API.Responses.Base
{
    using System.Collections.Generic;

    public class BaseTableResponse<T>
        where T : class
    {
        public List<T> Items { get; set; }

        public int Total { get; set; }

        public string Type { get; set; }

        public string? Message { get; set; }
    }
}
