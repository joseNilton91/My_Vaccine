using Microsoft.Extensions.Hosting.Internal;
using System.ComponentModel.DataAnnotations;

namespace MyVaccineWebApi.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public List<Dependent> Dependents { get; set; } = new List<Dependent>();
        public List<FamilyGroup> FamilyGroups { get; set; } = new List<FamilyGroup>();
        public List<VaccineRecord> VaccineRecords { get; set; } = new List<VaccineRecord>();
        public List<Allergy> Allergies { get; set; } = new List<Allergy>();
    }
}
