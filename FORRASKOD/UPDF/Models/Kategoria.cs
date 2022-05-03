using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPDF.Models
{
    public partial class Kategoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Kategory ID")]
        public int Azon { get; set; }

        [Display(Name = "Kategory name")]
        public string Megnevezes { get; set; } = null!;
    }
}