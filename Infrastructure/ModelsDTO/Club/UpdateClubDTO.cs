using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsDTO.Club
{
    public class UpdateClubDTO
    {
        public int TrophyCount { get; set; }
        public string Coach { get; set; }
        public decimal BudgetInformation { get; set; }
    }
}
