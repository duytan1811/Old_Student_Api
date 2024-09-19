namespace STM.Common.Constants
{
    public static class MenuConstants
    {
        public static class Keys
        {
            // Lobby
            public const string Booking = "booking";
            public const string Lobby = "lobby";

            // Order
            public const string Order = "order";
            public const string DraftOrder = "draftOrder";

            // Product
            public const string ProductMenuType = "productMenuType";
            public const string ProductType = "productType";
            public const string ProductGroup = "productGroup";
            public const string Product = "product";
            public const string Supplier = "supplier";
            public const string Inventory = "inventory";

            // Customer
            public const string Customer = "customer";

            // User
            public const string User = "user";

            // Accouting
            public const string AccountingTransaction = "accountingTransaction";
            public const string AccountingDebt = "accountingDebt";

            // Discount
            public const string Discount = "discount";

            // Statistics
            public const string StatisticsProduct = "statisticsProduct";
            public const string StatisticsOrder = "statisticsOrder";
            public const string StatisticsCustomer = "statisticsCustomer";

            // Setting
            public const string Setting = "setting";
            public const string Role = "role";
            public const string TimeKeeping = "timeKeeping";
            public const string WorkShift = "workShift";

            public static readonly List<string> KeyList = new List<string>()
            {
                Booking,
                Lobby,
                Order,
                DraftOrder,
                ProductMenuType,
                ProductGroup,
                Product,
                ProductType,
                ProductGroup,
                Supplier,
                Inventory,
                Customer,
                User,
                AccountingTransaction,
                AccountingDebt,
                Discount,
                StatisticsProduct,
                StatisticsOrder,
                StatisticsCustomer,
                Setting,
                Role,
                TimeKeeping,
                WorkShift,
            };
        }
    }
}
