namespace STM.Common.Constants
{
    public static class Messages
    {
        // Login
        public const string LoginIncorrect = "Tài khoản hoặc mật khẩu không chính xác";
        public const string LoginUserNotFound = "Không tìm thấy thông tin tài khoản";
        public const string LoginUserLocked = "Tài khoản đã bị khóa";

        // CRUD
        public const string CreateSuccess = "Thêm {0} thành công";
        public const string CreateFail = "Thêm {0} thất bại";
        public const string UpdateSuccess = "Cập nhật {0} thành công";
        public const string UpdateFail = "Thêm {0} thất bại";
        public const string DeleteSuccess = "Xóa {0} thành công";
        public const string DeleteFail = "Thêm {0} thất bại";
        public const string CannotDelete = "Không thể xóa {0}. Thông tin được liên kết với chức năng khác";
        public const string UpdateDisplaySuccess = "UpdateDisplaySuccess";
        public const string ImportSuccess = "Import {0} thành công";
        public const string ChangePassword = "Thay đổi mật khẩu thành công";
        public const string ApplyJob = "Ứng tuyển thành công";
        public const string EventRegister = "Đăng ký tham gia sự kiện thành công";
        public const string SurveySuccess = "Thực hiện khảo sát thành công";

        // System
        public const string Exception = "Đã xảy ra lỗi hệ thống";
        public const string NotFound = "Không tìm thấy thông tin";
        public const string Exists = "{0} đã tồn tại";
        public const string FileEmpty = "FileEmpty";
    }
}
