﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
   public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int ClubId { get; set; }
        public DateTime Year { get; set; }
        public int? Goals { get; set; }
        public int? Assists { get; set; }
    }
}
