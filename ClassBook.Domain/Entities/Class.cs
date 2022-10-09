namespace ClassBook.Domain.Entities;

public class Class
{
    public int Id { get; set; }
    public string ClassNumber { get; set; }
    public int NumberOfComputers { get; set; }
    public int Floor { get; set; }

    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }


    public ICollection<User> Users { get; set; }
}