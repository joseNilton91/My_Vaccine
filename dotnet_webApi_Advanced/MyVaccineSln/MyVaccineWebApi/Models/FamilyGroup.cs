using System.ComponentModel.DataAnnotations;

namespace MyVaccineWebApi.Models
{
    public class FamilyGroup
    {
        [Key]
        public int IdFamilyGroup { get; set; }
        public required string Name { get; set; }
        public required List <User> Users { get; set; }
    }
}
