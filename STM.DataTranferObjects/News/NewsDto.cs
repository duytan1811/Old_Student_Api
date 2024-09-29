﻿namespace STM.DataTranferObjects.News
{
    using STM.DataTranferObjects.Base;

    public class NewsDto : BaseDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public string Type { get; set; }

        public string? Content { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? CountMember { get; set; }
    }
}