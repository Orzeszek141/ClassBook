﻿using ClassBook.DAL.Fakers;

namespace ClassBook.DAL;

public class Seeder
{
    public static void SeedData(MyDbContext context)
    {
        if (!context.Users.Any())
        {
            context.AddRange(UserFaker.FakeUsers());
            context.SaveChanges();
        }

        if (!context.Faculties.Any())
        {
            context.AddRange(FacultyFaker.FakeFaculties());
            context.SaveChanges();
        }

        if (!context.UserInfos.Any())
        {
            context.AddRange(UserInfoFaker.FakeUserInfos());
            context.SaveChanges();
        }

        if (!context.Classes.Any())
        {
            context.AddRange(ClassFaker.FakeClasses());
            context.SaveChanges();
        }
    }
}