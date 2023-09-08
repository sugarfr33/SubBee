namespace SubBee.Api.Models.Dtos
{
    public class LoginDto
    {
        public required string Username { get; set; }

        public string Email { get; set; } = string.Empty;

        public required string Password { get; set; }
    }
}
