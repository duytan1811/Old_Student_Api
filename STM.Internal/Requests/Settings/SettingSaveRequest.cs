namespace STM.API.Requests.Settings
{
    public class SettingSaveRequest
    {
        public string Type { get; set; }

        public string Key { get; set; }

        public string? Value { get; set; }
    }
}
