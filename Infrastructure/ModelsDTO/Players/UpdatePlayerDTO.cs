using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsDTO.Players
{
    public class UpdatePlayerDTO
    {
        public string Position { get; set; }
        public int? Goals { get; set; }
        public int? Assists { get; set; }
    }
}
