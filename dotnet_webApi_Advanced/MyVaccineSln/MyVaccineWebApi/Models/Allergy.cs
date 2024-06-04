using System.ComponentModel.DataAnnotations;

namespace MyVaccineWebApi.Models;

public class Allergy
{
    [Key]
    public int IdAllergy { get; set; }
    public required string NameAllergy { get; set; }
    public int IdUser { get; set; }
    public required User User { get; set; }
}
