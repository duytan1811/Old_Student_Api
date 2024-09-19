namespace STM.Common.Constants
{
    public static class AreaConstants
    {
        public static class AreaKey
        {
            public const string FrontYard = "FrontYard";
            public const string BackYard = "BackYard";
            public const string VIPArea = "VIPArea";

            public static readonly List<string> Keys = new List<string>()
            {
                FrontYard,
                BackYard,
                VIPArea,
            };
        }

        public static class AreaName
        {
            public const string FrontYard = "Khu sân trước";
            public const string BackYard = "Khu sân sau";
            public const string VIPArea = "Khu VIP";

            public static string GetAreaName(string key)
            {
                switch (key)
                {
                    case AreaKey.FrontYard:
                        return FrontYard;
                    case AreaKey.BackYard:
                        return BackYard;
                    case AreaKey.VIPArea:
                        return VIPArea;

                    default: return key;
                }
            }
        }
    }
}
