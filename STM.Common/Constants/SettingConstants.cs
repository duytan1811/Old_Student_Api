namespace STM.Common.Constants
{
    public static class SettingConstants
    {
        public static List<string> GetSetingKeyOfType(string type)
        {
            switch (type)
            {
                case Types.General:
                    return new List<string>()
                    {
                        Keys.WebName,
                        Keys.Phone,
                        Keys.Email,
                        Keys.EmailSupportCustomer,
                        Keys.Province,
                        Keys.District,
                        Keys.Village,
                        Keys.Address,
                        Keys.TimeZone,
                        Keys.Currency,
                        Keys.OrderCodeStartWith,
                        Keys.OrderCodeEndWith,
                    };
                default: return new List<string>();
            }
        }

        public static class Types
        {
            public const string General = "general";
            public const string Shipment = "shipment";
            public const string Transaction = "transaction";
            public const string Website = "website";

            public static readonly List<string> TypeList = new List<string>()
            {
                General,
                Shipment,
                Transaction,
                Website,
            };
        }

        public static class Keys
        {
            // General
            public const string WebName = "webName";
            public const string Phone = "phone";
            public const string Email = "email";
            public const string EmailSupportCustomer = "emailSupportCustomer";
            public const string Province = "province";
            public const string District = "district";
            public const string Village = "village";
            public const string Address = "Address";
            public const string TimeZone = "timeZone";
            public const string Currency = "currency";
            public const string OrderCodeStartWith = "orderCodeStartWith";
            public const string OrderCodeEndWith = "orderCodeEndWith";
        }
    }
}
