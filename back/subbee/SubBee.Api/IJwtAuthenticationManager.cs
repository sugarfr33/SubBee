namespace SubBee.Api
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
