namespace STM.API.Responses.Base
{
    public class BaseItemResponse
    {
        public int Index { get; set; }

        public Guid Id { get; set; }

        public int? Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public Guid? CreatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedById { get; set; }
    }
}
