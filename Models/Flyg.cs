namespace FlygplatsApi.Models
{
    public class Flyg
    {
        public long Id { get; set; }
       public DateTime Avgang { get; set; }
        public DateTime Ankomst { get; set; }
        public string? Flygnummer { get; set; }
        public string? Flygbolag { get; set; }
        public bool Boarding { get; set; }
    }
}   