namespace NevezesAPI.Models
{
    public partial class Korcsoport
    {
        public int Azon { get; set; }
        public string Megnevezes { get; set; } = null!;
        public int Minimum { get; set; }
        public int Maximum { get; set; }
    }
}