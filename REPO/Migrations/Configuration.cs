using System.Collections.Generic;
using POCO.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace REPO.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<REPO.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(REPO.Context context)
        {
            var clients = new List<Client>
{
    new Client {FirstName = "Dan", LastName = "Simmons"},
    new Client {FirstName = "Bob", LastName = "Builder"},
    new Client {FirstName = "Scott", LastName = "Markov"}
};

            clients.ForEach(client => context.Clients.AddOrUpdate(c => c.FirstName, client));

            context.SaveChanges();

            var projects = new List<Project>
{
    new Project
    {
        Client = context.Clients.Single(c => c.FirstName == "Dan"),
        StartDate = new DateTime(2015, 10, 15),
        EndDate = new DateTime(2016, 10, 15),
        Title = "Entity Framework Project"
    },
    new Project
    {
        Client = context.Clients.Single(c => c.FirstName == "Bob"),
        StartDate = new DateTime(2015, 10, 15),
        EndDate = new DateTime(2016, 10, 15),
        Title = "Bob's Important Project"
    },
    new Project
    {
        Client = context.Clients.Single(c => c.FirstName == "Scott"),
        StartDate = new DateTime(2015, 10, 15),
        EndDate = new DateTime(2016, 10, 15),
        Title = "Some Other Project"
    }
};

            projects.ForEach(project => context.Projects.AddOrUpdate(p => p.Title, project));
            context.SaveChanges();

            var invoices = new List<Invoice>
{
    new Invoice
    {
        AmountDue = 34000m,
        DueDate = new DateTime(2016, 12, 31),
        ProjectID = projects.Single(p =>
            p.Client == clients.Single(c => c.FirstName == "Dan")).ID
    },
    new Invoice
    {
        AmountDue = 50000m,
        DueDate = new DateTime(2016, 12, 31),
        ProjectID = projects.Single(p =>
            p.Client == clients.Single(c => c.FirstName == "Bob")).ID
    },
    new Invoice
    {
        AmountDue = 2000m,
        DueDate = new DateTime(2016, 12, 31),
        ProjectID = projects.Single(p =>
            p.Client == clients.Single(c => c.FirstName == "Scott")).ID
    }
};
            invoices.ForEach(invoice => context.Invoices.AddOrUpdate(i => i.Project, invoice));
            context.SaveChanges();
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
