using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MyVaccineWebApi.Models
{
    public class Dependent
    {
        [Key]
        public int IdDependent { get; set; }
        public required string Name { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required int IdUser { get; set; }
        // Quita la validación de 'User.Password'
        public required User User { get; set; }
        public List<VaccineRecord> VaccineRecords { get; set; } = new List<VaccineRecord>();
    }
}

