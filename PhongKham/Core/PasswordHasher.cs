using System.Security.Cryptography;

namespace PhongKham.Core;

public static class PasswordHasher
{
    private const int Iterations = 600_000;
    public static string Hash(string password)
    {
        ArgumentException.ThrowIfNullOrEmpty(password);
        byte[] salt = RandomNumberGenerator.GetBytes(16);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, 32);
        return $"PBKDF2-SHA256${Iterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
    }

    public static bool Verify(string? password, string? encoded)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(encoded) || encoded.Length > 256)
            return false;
        var parts = encoded.Split('$');
        if (parts.Length != 4 || parts[0] != "PBKDF2-SHA256" || !int.TryParse(parts[1], out int rounds) || rounds < 10000 || rounds > 2000000)
            return false;
        try
        {
            var salt = Convert.FromBase64String(parts[2]);
            var expected = Convert.FromBase64String(parts[3]);
            if (salt.Length != 16 || expected.Length != 32)
                return false;
            var actual = Rfc2898DeriveBytes.Pbkdf2(password, salt, rounds, HashAlgorithmName.SHA256, 32);
            return CryptographicOperations.FixedTimeEquals(actual, expected);
        }
        catch (FormatException)
        {
            return false;
        }
    }
}