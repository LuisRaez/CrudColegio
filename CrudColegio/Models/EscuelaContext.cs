using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudColegio.Models;

public partial class EscuelaContext : DbContext
{
    public EscuelaContext()
    {
    }

    public EscuelaContext(DbContextOptions<EscuelaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Aula> Aulas { get; set; }

    public virtual DbSet<AulaDocente> AulaDocentes { get; set; }

    public virtual DbSet<Docente> Docentes { get; set; }

    //Estoy cambiando esta conexion por defecto por la que se colocó en el appsetting que referencio en Program.cs
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // => optionsBuilder.UseSqlServer("Server=DESKTOP-MU9FF4Q;DataBase=Escuela;Trusted_Connection=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.AlumnoId).HasName("PK__Alumnos__D35EA68AFA399BED");

            entity.Property(e => e.AlumnoId).HasColumnName("alumno_id");
            entity.Property(e => e.AulaId).HasColumnName("aula_id");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.AulaDocente).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.AulaDocenteId)
                .HasConstraintName("FK__Alumnos__AulaDoc__31EC6D26");

            entity.HasOne(d => d.Aula).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.AulaId)
                .HasConstraintName("FK__Alumnos__aula_id__2B3F6F97");
        });

        modelBuilder.Entity<Aula>(entity =>
        {
            entity.HasKey(e => e.AulaId).HasName("PK__Aulas__AEB9440674023D3A");

            entity.Property(e => e.AulaId)
                .ValueGeneratedNever()
                .HasColumnName("aula_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<AulaDocente>(entity =>
        {
            entity.HasKey(e => e.AulaDocenteId).HasName("PK__AulaDoce__639EAFFBF135C59A");

            entity.ToTable("AulaDocente");

            entity.HasOne(d => d.Aula).WithMany(p => p.AulaDocentes)
                .HasForeignKey(d => d.AulaId)
                .HasConstraintName("FK__AulaDocen__AulaI__300424B4");

            entity.HasOne(d => d.Docente).WithMany(p => p.AulaDocentes)
                .HasForeignKey(d => d.DocenteId)
                .HasConstraintName("FK__AulaDocen__Docen__30F848ED");
        });

        modelBuilder.Entity<Docente>(entity =>
        {
            entity.HasKey(e => e.DocenteId).HasName("PK__Docentes__32BA4B10A1A9B07D");

            entity.Property(e => e.DocenteId).HasColumnName("docente_id");
            entity.Property(e => e.Materia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("materia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
