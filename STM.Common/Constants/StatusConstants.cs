namespace STM.Common.Constants
{
    using STM.Common.Enums;
    using STM.Common.Utilities;

    public static class StatusConstants
    {
        public const string InActive = "Không hoạt động";
        public const string Active = "Hoạt động";
        public const string InProgress = "Đang thực hiện";
        public const string Cancel = "Hủy bỏ";

        public static readonly List<string> StatusNames = new List<string>
        {
            InActive,
            Active,
            InProgress,
            Cancel,
        };

        public static int GetStatusValue(string statusName)
        {
            switch (statusName)
            {
                case InActive:
                    return StatusEnum.Inactive.AsInt();
                    break;
                case Active:
                    return StatusEnum.Active.AsInt();
                    break;
                case InProgress:
                    return StatusEnum.InProgress.AsInt();
                    break;
                case Cancel:
                    return StatusEnum.Cancel.AsInt();
                    break;

                default: return StatusEnum.Inactive.AsInt();
            }
        }

        public static class User
        {
            public const string Locked = "locked";
            public const string TempLock = "temp_lock";
        }
    }
}
