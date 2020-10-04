﻿using System;
using Microsoft.EntityFrameworkCore;
using LollBlog.Shared;
namespace LollBlog.Server.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 3, DepartmentName = "Payroll" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 4, DepartmentName = "Admin" });
            //
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "John",
                    LastName = "Hastings",
                    Email = "David@pragimtech.com",
                    DateOfBrith = new DateTime(1980, 10, 5),
                    Gender = Gender.Male,
                    DepartmentId = 1,
                    PhotoPath = "images/john.png"
                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Sam",
                    LastName = "Galloway",
                    Email = "Sam@pragimtech.com",
                    DateOfBrith = new DateTime(1981, 12, 22),
                    Gender = Gender.Male,
                    DepartmentId = 2,
                    PhotoPath = "images/sam.jpg"
                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Mary",
                    LastName = "Smith",
                    Email = "mary@pragimtech.com",
                    DateOfBrith = new DateTime(1979, 11, 11),
                    Gender = Gender.Female,
                    DepartmentId = 3,
                    PhotoPath = "images/mary.png"
                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 4,
                    FirstName = "Sara",
                    LastName = "Longway",
                    Email = "sara@pragimtech.com",
                    DateOfBrith = new DateTime(1982, 9, 23),
                    Gender = Gender.Female,
                    DepartmentId = 4,
                    PhotoPath = "images/sara.png"
                });
        }
    }
}
