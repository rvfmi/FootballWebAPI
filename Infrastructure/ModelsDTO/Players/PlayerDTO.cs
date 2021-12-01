using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsDTO.Players
{
    public class PlayerDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public DateTime Year { get; set; }
        public int? Goals { get; set; }
        public int? Assists { get; set; }
    }
}
