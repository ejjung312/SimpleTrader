using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.AuthenticationServices;

namespace SimpleTrader.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        Account CurrentAccount { get; }

        event Action StateChanged;
        bool IsLoggedIn { get; }

        Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);
        Task Login(string username, string password);
        void Logout();
    }
}
