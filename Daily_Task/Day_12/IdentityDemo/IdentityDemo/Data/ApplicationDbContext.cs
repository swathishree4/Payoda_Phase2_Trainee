﻿using IdentityDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Employee> Employees { get; set; }  
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
