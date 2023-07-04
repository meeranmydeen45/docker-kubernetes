namespace UserManagement.Models
{
    public class ConfigSetting
    {
        public string KeyOne { get; set; }
        public string KeyTwo { get; set; }
        public NestedSetting KeyThree { get; set; }
    }
}
