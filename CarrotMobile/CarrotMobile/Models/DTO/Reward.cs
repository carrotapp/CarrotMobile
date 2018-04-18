using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CarrotMobile.Models.DTO
{
    public class Reward
    {
        [JsonProperty("Currency")]
        public string Currency { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ProviderName")]
        public string ProviderName { get; set; }

        [JsonProperty("Ratio")]
        public int Ratio { get; set; }

        [JsonProperty("How")]
        public string How { get; set; }

        [JsonProperty("InforUrl")]
        public string InforUrl { get; set; }

        [JsonProperty("Summary")]
        public string Summary { get; set; }

        [JsonProperty("Where")]
        public string Where { get; set; }
    }
}