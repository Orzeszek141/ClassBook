namespace ClassBook.BLL.Authorization.PasswordHashers;

internal sealed class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

    public bool VerifyPassword(string givenPassword, string passwordHash) => BCrypt.Net.BCrypt.Verify(givenPassword, passwordHash);
}