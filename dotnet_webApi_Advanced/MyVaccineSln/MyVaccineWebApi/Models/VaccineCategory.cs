using System.ComponentModel.DataAnnotations;

namespace MyVaccineWebApi.Models
{
    public class VaccineCategory
    {
        [Key]
        public int IdVaccineCategory { get; set; }
        public required string Name { get; set; }

        public required List<Vaccine> Vaccines { get; set; } = new List<Vaccine>();
    }
}
