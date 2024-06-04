using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyVaccineWebApi.Models
{
    public class MyVaccineAppDbContext: IdentityDbContext<IdentityUser>
    {
        public MyVaccineAppDbContext(DbContextOptions<MyVaccineAppDbContext> options) :
            base(options) { 
        
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<VaccineCategory> VaccineCategories { get; set;}
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<VaccineRecord> VaccineRecords { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<FamilyGroup> FamilyGroups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*modelBuilder.Entity<IdentityUser>()
            .HasKey(u => u.Id);

            modelBuilder.Entity<IdentityRole>()
              .HasKey(r => r.Id);

            modelBuilder.Entity<IdentityUserRole<string>>()
               .HasKey(r => new { r.UserId, r.RoleId });

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey });*/


            modelBuilder.Entity<User>(entity =>
            {

                entity.Property(u => u.UserName) // creando los atributos de cada tabla o clase
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(100);
            });

            modelBuilder.Entity<Dependent>(entity =>
            {
                entity.Property(d => d.Name).IsRequired().HasMaxLength(158);

                entity.HasOne(d => d.User)
                .WithMany(d => d.Dependents)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<VaccineCategory>(entity =>
            {
                entity.Property(vc => vc.Name)
                .IsRequired()
                .HasMaxLength(158);
            });


            modelBuilder.Entity<Vaccine>(entity =>
            {
                entity.Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(158);

                entity.HasMany(v => v.Categories)
                .WithMany(vc => vc.Vaccines)
                .UsingEntity(j => j.ToTable("VaccineCategoryVaccines"));
            });

            modelBuilder.Entity<VaccineRecord>(entity =>
            {
                entity.Property(vr => vr.DateAdministered)
                .IsRequired()
                .HasMaxLength(158);

                entity.Property(vr => vr.AdministeredLocation)
               .IsRequired()
               .HasMaxLength(158);

                entity.Property(vr => vr.AdministeredBy)
               .IsRequired()
               .HasMaxLength(158);

                entity.HasOne(vr => vr.User)
                .WithMany(u => u.VaccineRecords)
                .HasForeignKey(vr => vr.IdUser)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(vr => vr.Dependent)
                .WithMany(d => d.VaccineRecords)
                .HasForeignKey(vr => vr.IdDependent)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(vr => vr.Vaccine)
                .WithMany()
                .HasForeignKey(vr => vr.IdVaccine)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Allergy>(entity =>
            {
                entity.Property(a => a.NameAllergy)
                .IsRequired()
                .HasMaxLength(158);

                entity.HasOne(a => a.User)
                .WithMany(u => u.Allergies)
                .HasForeignKey(a => a.IdUser)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<FamilyGroup>(entity =>
            {
                entity.Property(fg => fg.Name)
                .IsRequired()
                .HasMaxLength(158);
            });


        }
    }

}
