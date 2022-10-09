using ClassBook.Domain.Entities;

namespace ClassBook.DAL.Fakers;

internal class ClassFaker
{
    public static List<Class> FakeClasses()
    {
        var classes = new List<Class>
        {
            new()
            {
                ClassNumber = "33B",
                Floor = 0,
                NumberOfComputers = 15,
                FacultyId = 1
            },
            new()
            {
                ClassNumber = "227A",
                Floor = 2,
                NumberOfComputers = 8,
                FacultyId = 2
            },
            new()
            {
                ClassNumber = "18C",
                Floor = 0,
                NumberOfComputers = 15,
                FacultyId = 2
            },
            new()
            {
                ClassNumber = "224",
                Floor = 4,
                NumberOfComputers = 15,
                FacultyId = 4
            },
            new()
            {
                ClassNumber = "428",
                Floor = -1,
                NumberOfComputers = 34,
                FacultyId = 3
            }
        };

        return classes;
    }
}