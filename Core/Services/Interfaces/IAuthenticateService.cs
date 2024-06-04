namespace Core.Services.Interfaces
{
    public interface IAuthenticateService
    {
        Task<bool> RegisterUser(string email, string password);
        Task<bool> Authenticate(string email, string password);
        Task Logout();
    }
}
