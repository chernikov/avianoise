namespace avianoise.Web.Services
{
    public interface IIdentityService
    {
        string Authenticate(string email, string password);

        string RenewToken(int userId);
    }
}
