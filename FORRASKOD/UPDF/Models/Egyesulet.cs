using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPDF.Models
{
    public partial class Egyesulet
    {
        public Egyesulet()
        {
            Versenyzok = new HashSet<Versenyzo>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Association ID")]
        public int Azon { get; set; }

        [Display(Name = "Association name")]
        public string Nev { get; set; } = null!;

        [Display(Name = "Association abbreviation")]
        public string Rovidites { get; set; } = null!;

        public virtual ICollection<Versenyzo> Versenyzok { get; set; }
    }
}