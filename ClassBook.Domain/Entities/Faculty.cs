using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBook.Domain.Entities;

public class Faculty
{
    public int Id { get; set; }
    public string FacultyName { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Street { get; set; }
    public string BuildingNb { get; set; }

    public ICollection<Class> Classes { get; set; }
}