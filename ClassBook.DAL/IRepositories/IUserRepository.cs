﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassBook.Domain.Entities;

namespace ClassBook.DAL.IRepositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<IEnumerable<User>> GetAllUsersSortedByLastNameAsync();
    Task<User> GetUserByEmail(string email);
    Task <(User, Class)> GetStudentAndClass(int studentId, int classId);
}