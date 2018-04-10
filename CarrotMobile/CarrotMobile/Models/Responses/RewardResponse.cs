using System;
using System.Collections.Generic;
using System.Text;

namespace CarrotMobile.Models.Responses
{
    public class RewardResponse
    {
        public bool Success { get; set; }
        public DTO.Reward Rewards { get; set; }
    }
}