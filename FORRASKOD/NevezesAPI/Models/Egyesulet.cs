namespace NevezesAPI.Models
{
    public partial class Egyesulet
    {
        public Egyesulet()
        {
            Versenyzok = new HashSet<Versenyzo>();
        }

        public int Azon { get; set; }
        public string Nev { get; set; } = null!;
        public string Rovidites { get; set; } = null!;

        public virtual ICollection<Versenyzo> Versenyzok { get; set; }
    }
}