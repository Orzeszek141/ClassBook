namespace ClassBook.Domain.Entities;

public class UserInfo
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}