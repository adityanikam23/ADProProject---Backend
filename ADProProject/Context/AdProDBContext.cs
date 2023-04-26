using System;
using System.Collections.Generic;
using ADProProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ADProProject.Context;

public partial class AdProDBContext : DbContext
{
    public AdProDBContext()
    {
    }

    public AdProDBContext(DbContextOptions<AdProDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Configuration> Configurations { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Rolemenu> Rolemenus { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ADITYA\\SQLEXPRESS;Initial Catalog=AdproDB; Integrated Security=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rolemenu>(entity =>
        {
            entity.HasOne(d => d.Menu).WithMany(p => p.Rolemenus).HasConstraintName("FK_rolemenus_menus");

            entity.HasOne(d => d.Role).WithMany(p => p.Rolemenus).HasConstraintName("FK_rolemenus_rolemenus");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasOne(d => d.Employee).WithMany(p => p.Users).HasConstraintName("FK_users_employees");

            entity.HasOne(d => d.Role).WithMany(p => p.Users).HasConstraintName("FK_users_roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
