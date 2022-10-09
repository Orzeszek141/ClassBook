using ClassBook.Domain.Entities;
using ClassBook.Domain.Enums;

namespace ClassBook.DAL.Fakers;

internal class UserFaker
{
    public static List<User> FakeUsers()
    {
        var users = new List<User>
        {
            new()
            {
                FirstName = "Hubert",
                LastName = "Orzech",
                Email = "hubert.orzech@o2.pl",
                Password = "$2a$11$fFZmfwWPMQxAwa7ZHyVF4.3Ay.Xnht6ZoW8WJSnomD/9dWLo8HxGG",
                Role = Role.Teacher
            },
            new()
            {
                FirstName = "Kamil",
                LastName = "Kowal",
                Email = "kamil.kowal@o2.pl",
                Password = "$2a$11$fFZmfwWPMQxAwa7ZHyVF4.3Ay.Xnht6ZoW8WJSnomD/9dWLo8HxGG",
                Role = Role.Student
            },
            new()
            {
                FirstName = "Karol",
                LastName = "Karolowski",
                Email = "karol.karolowski@o2.pl",
                Password = "$2a$11$fFZmfwWPMQxAwa7ZHyVF4.3Ay.Xnht6ZoW8WJSnomD/9dWLo8HxGG",
                Role = Role.Student
            },
            new()
            {
                FirstName = "Wiktoria",
                LastName = "Wakowska",
                Email = "wiktoria.wakowska@o2.pl",
                Password = "$2a$11$fFZmfwWPMQxAwa7ZHyVF4.3Ay.Xnht6ZoW8WJSnomD/9dWLo8HxGG",
                Role = Role.Student
            },
            new()
            {
                FirstName = "Dominik",
                LastName = "Sadowski",
                Email = "dominik.sadowski@o2.pl",
                Password = "$2a$11$fFZmfwWPMQxAwa7ZHyVF4.3Ay.Xnht6ZoW8WJSnomD/9dWLo8HxGG",
                Role = Role.Teacher
            },
            new()
            {
                FirstName = "Karolina",
                LastName = "Pilska",
                Email = "karolina.pilska@o2.pl",
                Password = "$2a$11$fFZmfwWPMQxAwa7ZHyVF4.3Ay.Xnht6ZoW8WJSnomD/9dWLo8HxGG",
                Role = Role.Student
            }
        };
        return users;
    }
}