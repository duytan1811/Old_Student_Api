namespace STM.API.Responses.Jobs
{
    using STM.API.Responses.Base;
    using STM.Common.Enums;
    using STM.Common.Utilities;

    public class JobResponseDto : BaseItemResponse
    {
        public string Title { get; set; }

        public string? Content { get; set; }

        public Guid? MajorId { get; set; }

        public string? MajorName { get; set; }

        public DateTime? StartDate { get; set; }

        public string? StartDateFormat => this.StartDate?.ToString("yyyy-MM-dd");

        public DateTime? EndDate { get; set; }

        public string? EndDateFormat => this.EndDate?.ToString("yyyy-MM-dd");

        public string CompanyName { get; set; }

        public List<string>? Skills { get; set; }

        public string? Address { get; set; }

        public int WorkType { get; set; }

        public string WorkTypeName => EnumHelper<WorkTypeEnum>.GetDisplayValue(this.WorkType);

        public string? FilePath { get; set; }

        public string? FilePathOriginal { get; set; }

        public string? FileName => !string.IsNullOrEmpty(this.FilePath) ? this.FilePath.Split("/")[4] : null;

        public bool IsApplyed { get; set; }

        public int CountApplyed { get; set; }

        public bool IsExpired => this.EndDate < DateTime.Now;

        public string? FileBase64
        {
            get
            {
                if (!string.IsNullOrEmpty(this.FilePathOriginal))
                {
                    byte[] bytes = File.ReadAllBytes(this.FilePathOriginal);
                    string file = Convert.ToBase64String(bytes);

                    return file;
                }

                return null;
            }
        }
    }
}
