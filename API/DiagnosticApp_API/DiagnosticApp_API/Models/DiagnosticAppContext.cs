using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DiagnosticApp_API.Models;

public partial class DiagnosticAppContext : DbContext
{
    public DiagnosticAppContext()
    {
    }

    public DiagnosticAppContext(DbContextOptions<DiagnosticAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Disease> Diseases { get; set; }

    public virtual DbSet<DiseasesSymptom> DiseasesSymptoms { get; set; }

    public virtual DbSet<Questionnaire> Questionnaires { get; set; }

    public virtual DbSet<Symptom> Symptoms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=DiagnosticApp; Trusted_Connection=true; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Disease>(entity =>
        {
            entity.HasKey(e => e.IdDisease).HasName("PK__Diseases__19C3C4972A711E4E");

            entity.Property(e => e.IdDisease).HasColumnName("Id_disease");
            entity.Property(e => e.Description)
                .HasMaxLength(1500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Specialist)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.SumWeight).HasColumnName("Sum_weight");
            entity.Property(e => e.SymptomsCount).HasColumnName("Symptoms_count");
        });

        modelBuilder.Entity<DiseasesSymptom>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Diseases_symptoms");

            entity.HasIndex(e => new { e.IdDisease, e.IdSymptom }, "D_s_idx");

            entity.Property(e => e.IdDisease).HasColumnName("Id_disease");
            entity.Property(e => e.IdSymptom).HasColumnName("Id_symptom");

            entity.HasOne(d => d.IdDiseaseNavigation).WithMany()
                .HasForeignKey(d => d.IdDisease)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Diseases___Id_di__619B8048");

            entity.HasOne(d => d.IdSymptomNavigation).WithMany()
                .HasForeignKey(d => d.IdSymptom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Diseases___Id_sy__628FA481");
        });

        modelBuilder.Entity<Questionnaire>(entity =>
        {
            entity.HasKey(e => e.IdQuestion).HasName("PK__Question__94CCD5908B343878");

            entity.ToTable("Questionnaire");

            entity.Property(e => e.IdQuestion).HasColumnName("Id_question");
            entity.Property(e => e.Question)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.QuestionValue)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Question_value");
        });

        modelBuilder.Entity<Symptom>(entity =>
        {
            entity.HasKey(e => e.IdSymptom).HasName("PK__Symptoms__5B11F5DA9F07FBED");

            entity.Property(e => e.IdSymptom).HasColumnName("Id_symptom");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
