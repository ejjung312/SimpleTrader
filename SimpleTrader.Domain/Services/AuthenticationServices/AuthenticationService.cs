using Microsoft.AspNet.Identity;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public async Task<Account> Login(string username, string password)
        {
            Account storedAccount = await _accountService.GetByUsername(username);

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedAccount.AccountHolder.PasswordHash, password);

            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }

            return storedAccount;
        }

        public async Task<RegisteractionResult> Register(string email, string username, string password, string confirmPassword)
        {
            RegisteractionResult result = RegisteractionResult.Success;

            if (password != confirmPassword)
            {
                result = RegisteractionResult.PasswordDoNotMatch;
            }

            Account emailAccount = await _accountService.GetByEmail(email);
            if (emailAccount != null)
            {
                result = RegisteractionResult.EmailAlreadyExists;
            }

            Account usernameAccount = await _accountService.GetByEmail(username);
            if (usernameAccount != null)
            {
                result = RegisteractionResult.UsernameAlreadyExists;
            }

            if (result == RegisteractionResult.Success)
            {
                string hashedPassword = _passwordHasher.HashPassword(password);

                User user = new User()
                {
                    Email = email,
                    Username = username,
                    PasswordHash = hashedPassword,
                    DatedJoined = DateTime.Now
                };

                Account account = new Account()
                {
                    AccountHolder = user,
                };

                await _accountService.Create(account);
            }

            return result;
        }
    }
}
