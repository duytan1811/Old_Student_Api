namespace STM.DataTranferObjects.Settings
{
    using STM.DataTranferObjects.Base;

    public class SettingSaveDto : BaseSaveDto
    {
        public string Type { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
