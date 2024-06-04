using System.ComponentModel.DataAnnotations;

namespace MyVaccineWebApi.Models
{
    public class Vaccine
    {
        [Key]
        public int IdVaccine { get; set; }
        public required string Name { get; set; }
        public  required List<VaccineCategory> Categories{ get; set; } = new List<VaccineCategory>();
        public bool RequiresBooster { get; set; }
    }
}
