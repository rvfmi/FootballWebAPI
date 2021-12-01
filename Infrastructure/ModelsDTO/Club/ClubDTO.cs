using Infrastructure.Models;
using Infrastructure.ModelsDTO.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.ModelsDTO.Club
{
    public class ClubDTO
    {
        public string ClubName { get; set; }
        public int Year { get; set; }
        public string City { get; set; }
        public int TrophyCount { get; set; }
        public string Coach { get; set; }
        public decimal BudgetInformation { get; set; }
        public List<PlayerDTO> Players { get; set; }
    }
}
