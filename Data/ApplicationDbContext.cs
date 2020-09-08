﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PartsInventory.Models;

namespace PartsInventory.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Part> Parts { get; set; }
        public DbSet<MyMessage> MyMessages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Scheduled> Scheduleds { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
