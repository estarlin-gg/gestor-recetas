using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace proyectoFinal.Models;

public partial class GestorRecetaContext : DbContext
{
    public GestorRecetaContext()
    {
    }

    public GestorRecetaContext(DbContextOptions<GestorRecetaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Recetum> Receta { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Initial Catalog=gestorReceta;User=sa;Password=303511239;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recetum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Receta__3214EC27AB83D16B");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApellidoPaciente).HasMaxLength(100);
            entity.Property(e => e.DireccionPaciente).HasMaxLength(255);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.NombreDoctor).HasMaxLength(100);
            entity.Property(e => e.NombrePaciente).HasMaxLength(100);
            entity.Property(e => e.TelefonoPaciente).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
