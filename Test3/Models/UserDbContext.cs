﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace Test3.Models
{
    class UserDbContext : DbContext
    {
         public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

    }
}
