using Newtonsoft.Json;

namespace RefreshToken.Abstract
{
    public class Resource
    {
        [JsonProperty(Order = -1)]
        public string Href { get; set; }
    }
}
