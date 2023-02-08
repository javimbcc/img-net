using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace imagenesDAL.DAO;

public partial class EjerciciosClaseContext : DbContext
{
    public EjerciciosClaseContext()
    {
    }

    public EjerciciosClaseContext(DbContextOptions<EjerciciosClaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Imagene> Imagenes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=ejercicios-clase;User Id=postgres;Password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Imagene>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("imagenes", "imagenes");

            entity.Property(e => e.ImagenCode)
                .HasColumnType("character varying")
                .HasColumnName("imagen_code");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
