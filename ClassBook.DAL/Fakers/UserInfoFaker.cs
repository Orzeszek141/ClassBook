using ClassBook.Domain.Entities;

namespace ClassBook.DAL.Fakers;

internal class UserInfoFaker
{
    public static List<UserInfo> FakeUserInfos()
    {
        var userinfos = new List<UserInfo>
        {
            new()
            {
                BirthDate = new DateTime(2000, 10, 1).ToUniversalTime(),
                PhoneNumber = "467808212",
                UserId = 1
            },
            new()
            {
                BirthDate = new DateTime(1992, 12, 18).ToUniversalTime(),
                PhoneNumber = "978001234",
                UserId = 2
            },
            new()
            {
                BirthDate = new DateTime(1995, 8, 11).ToUniversalTime(),
                PhoneNumber = "786127670",
                UserId = 3
            },
            new()
            {
                BirthDate = new DateTime(2001, 11, 24).ToUniversalTime(),
                PhoneNumber = "461099454",
                UserId = 4
            },
            new()
            {
                BirthDate = new DateTime(1997, 3, 14).ToUniversalTime(),
                PhoneNumber = "177189824",
                UserId = 5
            },
            new()
            {
                BirthDate = new DateTime(1999, 5, 27).ToUniversalTime(),
                PhoneNumber = "109448235",
                UserId = 6
            }
        };

        return userinfos;
    }
}