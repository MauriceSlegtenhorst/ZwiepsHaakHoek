using Contentful.Core.Models;
using Newtonsoft.Json;

namespace ZwiepsHaakHoek.Models.Contentful
{
    public class CFLanguageIcon
    {
        public string LanguageCode { get; set; }
        [JsonProperty("flag")]
        public Asset LanguageIcon { get; set; }
    }
}
