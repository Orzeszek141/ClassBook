using ClassBook.Domain.Entities;

namespace ClassBook.DAL.Fakers;

internal class FacultyFaker
{
    public static List<Faculty> FakeFaculties()
    {
        var faculties = new List<Faculty>
        {
            new()
            {
                BuildingNb = "27",
                FacultyName = "Faculty of Electrical Engineering",
                City = "Lublin",
                PostalCode = "27-470",
                Street = "Nadbystrzycka"
            },
            new()
            {
                BuildingNb = "84A",
                FacultyName = "University of Medical Sciences",
                City = "Warszawa",
                PostalCode = "48-300",
                Street = "Żwirki"
            },
            new()
            {
                BuildingNb = "27",
                FacultyName = "Faculty of Information Technology",
                City = "Lublin",
                PostalCode = "27-470",
                Street = "Nadbystrzycka"
            },
            new()
            {
                BuildingNb = "102C",
                FacultyName = "University of Banking",
                City = "Gdańsk",
                PostalCode = "02-004",
                Street = "Grunwaldzka"
            }
        };

        return faculties;
    }
}