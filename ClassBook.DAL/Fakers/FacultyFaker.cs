using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassBook.Domain.Entities;
using ClassBook.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ClassBook.DAL.Fakers
{
    internal class FacultyFaker
    {
        public static List<Faculty> FakeFaculties()
        {
            var faculties = new List<Faculty>{
                new Faculty
                {
                    BuildingNb = "27",
                    FacultyName = "Faculty of Electrical Engineering",
                    City = "Lublin",
                    PostalCode = "27-470",
                    Street = "Nadbystrzycka"
                },
                new Faculty
                {
                    BuildingNb = "84A",
                    FacultyName = "University of Medical Sciences",
                    City = "Warszawa",
                    PostalCode = "48-300",
                    Street = "Żwirki"
                },
                new Faculty
                {
                    BuildingNb = "27",
                    FacultyName = "Faculty of Information Technology",
                    City = "Lublin",
                    PostalCode = "27-470",
                    Street = "Nadbystrzycka"
                },
                new Faculty
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
}
