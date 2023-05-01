using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DAL;

public class ApplicationDBContext : DbContext
{
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<Document> Documents { get; set; }

    public string DbPath { get; }

    public ApplicationDBContext()
    {
        // var folder = Environment.SpecialFolder.LocalApplicationData;
        // var path = Environment.GetFolderPath(folder);
        // DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
    : base(options)
    { }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // options.UseInMemoryDatabase($"app");
    }
}