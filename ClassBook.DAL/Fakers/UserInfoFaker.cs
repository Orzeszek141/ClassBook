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
    internal class UserInfoFaker
    {
        public static List<UserInfo> FakeUserInfos()
        {
            var userinfos = new List<UserInfo>{
                new UserInfo
                {
                    BirthDate = new DateTime(2000,10,1).ToLocalTime(),
                    PhoneNumber = "467808212",
                    UserId = 1,
                },
                new UserInfo
                {
                    BirthDate = new DateTime(1992, 12, 18).ToLocalTime(),
                    PhoneNumber = "978001234",
                    UserId = 2,
                },
                new UserInfo
                {
                    BirthDate = new DateTime(1995, 8, 11).ToLocalTime(),
                    PhoneNumber = "786127670",
                    UserId = 3,
                },
                new UserInfo
                {
                    BirthDate = new DateTime(2001, 11, 24).ToLocalTime(),
                    PhoneNumber = "461099454",
                    UserId = 4,
                },
                new UserInfo
                {
                    BirthDate = new DateTime(1997, 3, 14).ToLocalTime(),
                    PhoneNumber = "177189824",
                    UserId = 5,
                },
                new UserInfo
                {
                    BirthDate = new DateTime(1999, 5, 27).ToLocalTime(),
                    PhoneNumber = "109448235",
                    UserId = 6,
                }
            };

            return userinfos;
        }
    }
}
