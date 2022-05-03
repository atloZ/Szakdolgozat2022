using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPDF.Models
{
    public partial class Nevezes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Entry ID")]
        public int Azon { get; set; }

        [Display(Name = "Choreography title")]
        public string? KoreoCim { get; set; }

        [Display(Name = "Competitor ID")]
        public int VersenyzoAzon { get; set; }

        [Display(Name = "Age Group ID")]
        public int KorcsoportAzon { get; set; }

        [Display(Name = "Kategory ID")]
        public int KategoriaAzon { get; set; }

        [Display(Name = "Style ID")]
        public int VersenySzamAzon { get; set; }

        [Display(Name = "Team ID")]
        public int CsapatAzon { get; set; }

        [Display(Name = "Music Path")]
        public string? ZenePath { get; set; }

        [Display(Name = "Data host ID")]
        public string RogzitoAzon { get; set; }

        public virtual Csapat CsapatAzonNavigation { get; set; } = null!;
        public virtual Kategoria KategoriaAzonNavigation { get; set; } = null!;
        public virtual Korcsoport KorcsoportAzonNavigation { get; set; } = null!;
        public virtual ApplicationUser RogzitoAzonNavigation { get; set; } = null!;
        public virtual VersenySzam VersenySzamAzonNavigation { get; set; } = null!;
        public virtual Versenyzo VersenyzoAzonNavigation { get; set; } = null!;
    }
}