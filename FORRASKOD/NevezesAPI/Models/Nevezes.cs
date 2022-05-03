namespace NevezesAPI.Models
{
    public partial class Nevezes
    {
        public int Azon { get; set; }
        public string? KoreoCim { get; set; }
        public int VersenyzoAzon { get; set; }
        public int KorcsoportAzon { get; set; }
        public int KategoriaAzon { get; set; }
        public int VersenySzamAzon { get; set; }
        public int CsapatAzon { get; set; }
        public string? ZenePath { get; set; }
        public string RogzitoAzon { get; set; }

        public virtual Csapat CsapatAzonNavigation { get; set; } = null!;
        public virtual Kategoria KategoriaAzonNavigation { get; set; } = null!;
        public virtual Korcsoport KorcsoportAzonNavigation { get; set; } = null!;
        public virtual Felhasznalo RogzitoAzonNavigation { get; set; } = null!;
        public virtual VersenySzam VersenySzamAzonNavigation { get; set; } = null!;
        public virtual Versenyzo VersenyzoAzonNavigation { get; set; } = null!;
    }
}