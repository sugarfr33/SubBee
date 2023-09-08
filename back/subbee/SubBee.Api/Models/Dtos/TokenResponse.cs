namespace SubBee.Api.Models.Dtos
{
    public class TokenResponse
    {
        public string TokenString { get; set; } = string.Empty;

        public DateTime ValidTo { get; set; }
    }
}
