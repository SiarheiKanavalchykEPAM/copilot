using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace bookDestributedLibrary3.Data.Models;

public partial class DbApplicationContext : DbContext
{
    public DbApplicationContext()
    {
    }

    public DbApplicationContext(DbContextOptions<DbApplicationContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=book-library;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
