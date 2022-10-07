﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassBook.DAL.Repositories
{
    internal sealed class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        public ClassRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Class>> GetAllClassesByFloorAsync(int floor)
        {
            return await Context.Classes.AsNoTracking().Where(c => c.Floor == floor).ToListAsync();
        }
    }
}
