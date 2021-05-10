using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Moving_App_Web_API.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BoxItem> BoxItem { get; set; }
        public virtual DbSet<Boxes> Boxes { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<UserBox> UserBox { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=behnketest.database.windows.net;Initial Catalog=MovingAppTesting;Persist Security Info=True;User ID=JonTheBrownDog;Password=HuracanBatman55");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoxItem>(entity =>
            {
                entity.HasKey(e => new { e.BoxId, e.ItemId });
            });

            modelBuilder.Entity<Boxes>(entity =>
            {
                entity.Property(e => e.BoxName).IsUnicode(false);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.ItemId).ValueGeneratedNever();

                entity.Property(e => e.ItemName).IsUnicode(false);
            });

            modelBuilder.Entity<UserBox>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BoxId });
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
