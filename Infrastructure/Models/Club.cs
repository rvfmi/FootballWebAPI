using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure
{
    public class Club
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string ClubName { get; set; }
        public int Year { get; set; }
        [Required]
        public string City { get; set; }
        public int TrophyCount { get; set; }
        public string Coach { get; set; }
        public decimal BudgetInformation { get; set; }
        public virtual List<Player> Players { get; set; }
        public virtual List<Stadium> Stadiums { get; set; }
    }
}
