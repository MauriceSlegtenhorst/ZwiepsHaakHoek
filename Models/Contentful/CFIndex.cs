using Contentful.Core.Models;
using Newtonsoft.Json;

namespace ZwiepsHaakHoek.Models.Contentful
{
    public class CFIndex
    {
        public SystemProperties Sys { get; set; }

        public Asset[] Images { get; set; }

        [JsonProperty("intro")]
        public Document IntroMarkup { get; set; }

        public CFProduct LatestProduct { get; set; }
    }
}
