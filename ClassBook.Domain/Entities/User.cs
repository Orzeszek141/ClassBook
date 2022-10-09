using ClassBook.Domain.Enums;

namespace ClassBook.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }

    public UserInfo UserInfo { get; set; }

    public ICollection<Class> Classes { get; set; }
}