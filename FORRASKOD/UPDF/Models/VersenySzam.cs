using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPDF.Models
{
    public partial class VersenySzam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Sir ID")]
        public int Azon { get; set; }

        [Display(Name = "Style")]
        public string Megnevezes { get; set; } = null!;

        [Display(Name = "Number of performers")]
        public int Letszam { get; set; }
    }
}