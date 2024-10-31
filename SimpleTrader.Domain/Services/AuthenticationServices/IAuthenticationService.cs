using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.AuthenticationServices
{
    public enum RegisteractionResult
    {
        Success,
        PasswordDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists,
    }

    public interface IAuthenticationService
    {
        public Task<RegisteractionResult> Register(string email, string username, string password, string confirmPassword);

        public Task<Account> Login(string username, string password);
    }
}
