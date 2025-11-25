using System.Security.Cryptography;

namespace Infrastructure.Identity;

public sealed class PasswordHasher : IPasswordHasher<User>, IPasswordHasher
{
    private const int _saltSize = 16;
    private const int _hashSize = 32;
    private const int _iterations = 210000;
    private readonly HashAlgorithmName _algorithm = HashAlgorithmName.SHA512;

    // Application-layer API
    public string HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(_saltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, _algorithm, _hashSize);

        return $"{Convert.ToBase64String(hash)}:{Convert.ToBase64String(salt)}";
    }

    // Identity API
    public string HashPassword(User user, string password)
    {
        return HashPassword(password);
    }

    // Identity API
    public PasswordVerificationResult VerifyHashedPassword(
        User user,
        string hashedPassword,
        string providedPassword)
    {
        return VerifyHashedPassword(providedPassword, hashedPassword);
    }

    // Application-layer API
    public PasswordVerificationResult VerifyHashedPassword(string providedPassword, string hashedPassword)
    {
        string[] parts = hashedPassword.Split(':');
        if (parts.Length != 2) return PasswordVerificationResult.Failed;

        if (!Convert.TryFromBase64String(parts[0], new byte[0], out int _) ||
            !Convert.TryFromBase64String(parts[1], new byte[0], out int _))
            return PasswordVerificationResult.Failed;

        byte[] hash = Convert.FromBase64String(parts[0]);
        byte[] salt = Convert.FromBase64String(parts[1]);

        byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(providedPassword, salt, _iterations, _algorithm, _hashSize);

        return CryptographicOperations.FixedTimeEquals(hash, inputHash)
            ? PasswordVerificationResult.Success
            : PasswordVerificationResult.Failed;
    }
}
