using System;
using System.Collections.Generic;
using System.Text;

namespace CarrotMobile.Models.DTO
{
    public class Reward
    {
        public string Currency { get; set; }
        public string How { get; set; }

        public string Image { get; set; }
        public string InforUrl { get; set; }

        public string Name { get; set; }
        public string ProviderName { get; set; }
        public int Ratio { get; set; }
        public string Summary { get; set; }
        public string Where { get; set; }
    }
}