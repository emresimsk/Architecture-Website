using DAL.DB;

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ArcEntitiy : DbContext
    {
        public ArcEntitiy()
            : base("name=ArcEntitiy")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AboutMe> AboutMe { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BlockIp> BlockIp { get; set; }
        public virtual DbSet<ContactPage> ContactPage { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<ImageFilePath> ImageFilePath { get; set; }
        public virtual DbSet<Mails> Mails { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
        public virtual DbSet<SocialMedia> SocialMedia { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AboutMe>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<BlockIp>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ContactPage>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Education>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ImageFilePath>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ImageFilePath>()
                .Property(e => e.ProjectID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Mails>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Project>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Skills>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SocialMedia>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);
        }
    }
}
