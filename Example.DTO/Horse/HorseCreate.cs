namespace Example.DTO.Horse
{
    public class HorseCreate
    {
        public string Name { get; set; }
        public int Starts { get; set; }
        public int Win { get; set; }
        public int Place { get; set; }
        public int Show { get; set; }
        public int Earnings { get; set; }
        public byte ColorId { get; set; }
        public int? SireId { get; set; }
        public int? DamId { get; set; }
    }
}
