namespace STM.Common.Utilities
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;

    public static class PasswordUtils
    {
        public static string HashPassword(this string password)
        {
            PasswordHasher<string> passwordHasher = new PasswordHasher<string>(
                    new OptionsWrapper<PasswordHasherOptions>(
                        new PasswordHasherOptions()
                        {
                            CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3,
                        }));

            string hashPassword = passwordHasher.HashPassword(null, password);
            return hashPassword;
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            PasswordHasher<string> passwordHasher = new PasswordHasher<string>(
                    new OptionsWrapper<PasswordHasherOptions>(
                        new PasswordHasherOptions()
                        {
                            CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3,
                        }));

            var verificationResult = passwordHasher.VerifyHashedPassword(null, hashedPassword, password);
            bool result = verificationResult == PasswordVerificationResult.Success;
            return result;
        }
    }
}
