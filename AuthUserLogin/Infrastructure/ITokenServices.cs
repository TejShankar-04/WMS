namespace AuthUserLogin.Infrastructure
{
    public interface ITokenServices
    {
        string CreateToken(string email);
    }
}
