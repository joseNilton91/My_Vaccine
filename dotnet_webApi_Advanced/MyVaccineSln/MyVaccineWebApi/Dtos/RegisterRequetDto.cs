namespace MyVaccineWebApi.Dtos
{
    public class RegisterRequetDto
    {
        public required string Username{ get; set; }
        public required string Password { get; set; }
        public required  string Email { get; set; }
    }
}
