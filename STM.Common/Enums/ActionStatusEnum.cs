namespace STM.Common.Enums
{
    public enum ActionStatusEnum
    {
        /// <summary>
        /// Thực hiện thành công.
        /// </summary>
        Success = 0,

        /// <summary>
        /// Không tìm thấy dữ liệu.
        /// </summary>
        NotFound = 1,

        /// <summary>
        /// Có phát sinh lịch sử hoạt động.
        /// </summary>
        HasHistory = 2,

        /// <summary>
        /// Điều kiện không hợp lệ.
        /// </summary>
        Fail = 3,

        /// <summary>
        /// Đã tồn tại.
        /// </summary>
        Exists = 4,

        /// <summary>
        /// Tài khoản đã tồn tại.
        /// </summary>
        UserNameExists = 5,

        /// <summary>
        /// Email đã tồn tại.
        /// </summary>
        EmailExists = 6,

        /// <summary>
        /// Số điện thoại đã tồn tại.
        /// </summary>
        PhoneExists = 7,

        /// <summary>
        /// Mã đã tồn tại.
        /// </summary>
        CodeExists = 8,
    }
}
