using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lab4_3_AspNetCoreMVC_BlindDating.Models
{
    public partial class BlindDatingContext : DbContext
    {
        public BlindDatingContext()
        {
        }

        public BlindDatingContext(DbContextOptions<BlindDatingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DatingProfile> DatingProfile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=BlindDating;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatingProfile>(entity =>
            {
                entity.Property(e => e.Bio)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserAccountId)
                    .IsRequired()
                    .HasColumnName("UserAccountID")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
