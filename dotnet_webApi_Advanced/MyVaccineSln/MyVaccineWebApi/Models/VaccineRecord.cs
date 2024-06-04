using System.ComponentModel.DataAnnotations;

namespace MyVaccineWebApi.Models
{
    public class VaccineRecord
    {
        [Key]
        public int IdVaccineRecord { get; set; }
        public int IdUser { get; set; }
        public required User User { get; set; }
        public int IdDependent{ get; set; }
        public required Dependent Dependent { get; set; }
        public int IdVaccine {  get; set; }
        public required Vaccine Vaccine{ get; set; }
        public  DateTime DateAdministered { get; set; }
        public required string  AdministeredLocation { get; set; }
        public required string AdministeredBy { get; set; }


    }
}
