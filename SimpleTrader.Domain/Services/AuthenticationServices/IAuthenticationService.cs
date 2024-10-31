using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.AuthenticationServices
{
    public enum RegistrationResult
    {
        Success,
        PasswordDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists,
    }

    public interface IAuthenticationService
    {
        public Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);

        public Task<Account> Login(string username, string password);
    }
}
