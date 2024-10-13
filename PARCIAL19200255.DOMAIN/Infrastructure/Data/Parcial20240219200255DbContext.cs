using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PARCIAL19200255.DOMAIN.Core.Entities;

namespace PARCIAL19200255.DOMAIN.Infrastructure.Data;

public partial class Parcial20240219200255DbContext : DbContext
{
    public Parcial20240219200255DbContext()
    {
    }

    public Parcial20240219200255DbContext(DbContextOptions<Parcial20240219200255DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mechanic> Mechanic { get; set; }
    public virtual DbSet<AutoParts> AutoParts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPLG1HNAVARRTI\\SQLEXPRESS;Database=Parcial20240219200255DB;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mechanic>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
