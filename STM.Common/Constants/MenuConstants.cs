namespace STM.Common.Constants
{
    public static class MenuConstants
    {
        public const string User = "Thành viên";
        public const string Student = "Sinh viên";
        public const string Setting = "Cấu hình";
        public const string Role = "Phân quyền";

        public static readonly List<string> KeyList = new List<string>()
            {
                User,
                Student,
                Setting,
                Role,
            };
    }
}
