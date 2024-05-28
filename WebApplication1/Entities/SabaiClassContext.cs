using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Entities;

public partial class SabaiClassContext : DbContext
{
    public SabaiClassContext()
    {
    }

    public SabaiClassContext(DbContextOptions<SabaiClassContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("server=127.0.0.1;port=13306;user=sabai_class;password=XsOC7X06TB;database=sabai_class");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<WebApplication1.Entities.Student> Student { get; set; } = default!;
}
