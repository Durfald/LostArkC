using LostArkAPI.Models.Base;

namespace LostArkAPI.Models.API
{
    public class APIKey:BaseModel
    {
        public string Key { get; set; } = string.Empty;
    }
}
