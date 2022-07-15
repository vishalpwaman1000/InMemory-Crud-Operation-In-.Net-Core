using InMemoryCrudOperation.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryCrudOperation.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions dbContext) : base(dbContext)
        {

        }

        public DbSet<UserDetails> UserDetails { get; set; }
    }
}
