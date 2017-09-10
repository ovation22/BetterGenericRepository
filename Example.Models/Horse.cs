using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Example.Models
{
    public sealed class Horse
    {
        public Horse()
        {
            SireOffspring = new HashSet<Horse>();
            DamOffspring = new HashSet<Horse>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public byte ColorId { get; set; }

        public int? SireId { get; set; }

        public int? DamId { get; set; }

        public int RaceStarts { get; set; }

        public int RaceWins { get; set; }

        public int RacePlace { get; set; }

        public int RaceShow { get; set; }

        public int Earnings { get; set; }

        public Color Color { get; set; }

        public ICollection<Horse> SireOffspring { get; set; }

        public Horse Sire { get; set; }

        public ICollection<Horse> DamOffspring { get; set; }

        public Horse Dam { get; set; }
    }
}