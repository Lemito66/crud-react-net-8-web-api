using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webApi.Models;

public partial class DbcrudContext : DbContext
{
    public DbcrudContext()
    {
    }

    public DbcrudContext(DbContextOptions<DbcrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employeer> Employeers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employeer>(entity =>
        {
            entity.HasKey(e => e.IdEmployeer).HasName("PK__employee__822CD2650D7ECA2D");

            entity.ToTable("employeers");

            entity.Property(e => e.IdEmployeer).HasColumnName("id_employeer");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
