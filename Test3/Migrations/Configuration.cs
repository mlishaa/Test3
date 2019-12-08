namespace Test3.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Test3.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Test3.Models.UserDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Test3.Models.UserDbContext context)
        {
            
        }
    }
}
