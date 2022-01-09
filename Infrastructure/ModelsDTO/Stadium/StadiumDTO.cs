using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsDTO.Stadium
{
    public class StadiumDTO
    {
        public string StadiumName { get; set; }
        public int ClubId { get; set; }
        public int Capacity { get; set; }
    }
}
