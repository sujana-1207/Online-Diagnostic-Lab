﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookTestAppointmentService
{
    public partial class DiagnosticLabContext : DbContext
    {
        public DiagnosticLabContext()
        {
        }

        public DiagnosticLabContext(DbContextOptions<DiagnosticLabContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TestAppointment> TestAppointments { get; set; }
        public virtual DbSet<TestResultsTab> TestResultsTabs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-6LVD3EJ\\MSSQLSERVER17;Initial Catalog=DiagnosticLab;Persist Security Info=True;User ID=sa;Password=admin123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestAppointment>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK__TestAppo__73951AED6772131E");

                entity.ToTable("TestAppointment");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PAYMENT_TYPE");
            });

            modelBuilder.Entity<TestResultsTab>(entity =>
            {
                entity.HasKey(e => e.TestId);

                entity.ToTable("TestResultsTab");

                entity.Property(e => e.TestId).ValueGeneratedNever();

                entity.Property(e => e.Result)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("User");

                entity.Property(e => e.Username)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
