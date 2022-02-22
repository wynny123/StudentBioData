using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentBioData.Data
{        //the bridge between the application and the database
    public class DatabaseContext : DbContext
    {
        //constructor
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        // what the database should know about when it is been generated
        public DbSet<Student> Students { get; set; } //where Student represent the class and Students the table in the database

        protected  override void OnModelCreating(ModelBuilder builder) // To put initial data into the database
        {
            builder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Wale",
                    LastName = "Adewale",
                    MiddleName = "Olawale",
                    DateOfBirth = new DateTime(2019-03-01),
                    Department = "Computer Science",
                    Level = "400",
                    LGA = "Igueben",
                    StateOfOrigin = "Edo",
                    Nationality = "Nigeria"
                },
                 new Student
                 {
                     Id = 2,
                     FirstName = "Awele",
                     LastName = "Uzordinma",
                     MiddleName = "Princess",
                     DateOfBirth = new DateTime(2019-03-01),
                     Department = "Computer Science",
                     Level = "400",
                     LGA = "Ika North",
                     StateOfOrigin = "Delta",
                     Nationality = "Nigeria"
                 }

                );
        }

    }
}
