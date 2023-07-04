﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace UserManagement.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get;set; }
    }
}
