namespace NevezesAPI.Models
{
    public partial class Versenyzo
    {
        public int SirAzon { get; set; }
        public int EgyesuletAzon { get; set; }
        public string Nev { get; set; } = null!;
        public string SzulHely { get; set; } = null!;
        public DateTime SzulDatum { get; set; }
        public int EngedelySzam { get; set; }
        public DateTime EngedelyErv { get; set; }

        public virtual Egyesulet EgyesuletAzonNavigation { get; set; } = null!;
    }
}