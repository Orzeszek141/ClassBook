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
    internal class ClassFaker
    {
        public static List<Class> FakeClasses()
        {
            var classes = new List<Class>{
                new Class
                {
                    ClassNumber = "33B",
                    Floor = 0,
                    NumberOfComputers = 15,
                    FacultyId = 1,
                },
                new Class
                {
                    ClassNumber = "227A",
                    Floor = 2,
                    NumberOfComputers = 8,
                    FacultyId = 2,
                },
                new Class
                {
                    ClassNumber = "18C",
                    Floor = 0,
                    NumberOfComputers = 15,
                    FacultyId = 2,
                },
                new Class
                {
                    ClassNumber = "224",
                    Floor = 4,
                    NumberOfComputers = 15,
                    FacultyId = 4,
                },
                new Class
                {
                    ClassNumber = "428",
                    Floor = -1,
                    NumberOfComputers = 34,
                    FacultyId = 3,
                }
            };

            return classes;
        }
    }
}
