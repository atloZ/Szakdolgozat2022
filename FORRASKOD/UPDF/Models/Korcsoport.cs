using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPDF.Models
{
    public partial class Korcsoport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Age group ID")]
        public int Azon { get; set; }

        [Display(Name = "Age group name")]
        public string Megnevezes { get; set; } = null!;

        [Display(Name = "Upper age limit")]
        public int Minimum { get; set; }

        [Display(Name = "Lower age limit")]
        public int Maximum { get; set; }
    }
}