namespace ClassBook.BLL.Authorization.PasswordHashers;

public interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyPassword(string givenPassword, string passwordHash);
}