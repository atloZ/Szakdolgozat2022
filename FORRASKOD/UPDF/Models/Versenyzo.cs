using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPDF.Models
{
    public partial class Versenyzo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Sir ID")]
        public int SirAzon { get; set; }

        [Display(Name = "Association ID")]
        public int EgyesuletAzon { get; set; }

        [Display(Name = "Competitor name")]
        public string Nev { get; set; } = null!;

        [Display(Name = "Place of birth")]
        public string SzulHely { get; set; } = null!;

        [Display(Name = "Birth date")]
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime SzulDatum { get; set; }

        [Display(Name = "License number")]
        public int EngedelySzam { get; set; }

        [Display(Name = "License validity")]
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EngedelyErv { get; set; }

        public virtual Egyesulet EgyesuletAzonNavigation { get; set; } = null!;
    }
}