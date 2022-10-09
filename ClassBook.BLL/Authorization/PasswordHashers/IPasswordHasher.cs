namespace ClassBook.BLL.Authorization.PasswordHashers;

internal interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyPassword(string givenPassword, string passwordHash);
}