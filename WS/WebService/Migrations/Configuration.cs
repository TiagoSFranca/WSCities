namespace WebService.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebService.ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebService.ModelContext context)
        {
            string sqlCommand = @"USE [WebService.ModelContext] 
                EXEC [dbo].[InsertData]";
            context.Database.ExecuteSqlCommand(sqlCommand);
            context.City.AddOrUpdate(
                data => data.Id,
                new City()
                {
                    Id = 1,
                    IdState = 1,
                    Name = "teste"
                }
                );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
