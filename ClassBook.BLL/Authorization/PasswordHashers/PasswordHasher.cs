namespace ClassBook.BLL.Authorization.PasswordHashers;

internal sealed class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string givenPassword, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(givenPassword, passwordHash);
    }
}