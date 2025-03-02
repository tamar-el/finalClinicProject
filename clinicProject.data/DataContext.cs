using System.Reflection.Emit;
using clinicProject.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



namespace clinicProject
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public DbSet<ClassDoctor> doctors { get; set; }
        public DbSet<ClassRoute> routes { get; set; }
        public DbSet<ClassPatient> patients { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionString"]);

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ClassDoctor>()
        //        .HasOne(c => c.User)
        //        .WithMany() // או WithOne אם זה 1:1
        //        .HasForeignKey(c => c.UserId)
        //        .OnDelete(DeleteBehavior.Restrict); // הגבלת מחיקה

        //    //modelBuilder.Entity<Turn>()
        //    //    .HasOne(t => t.doctor)
        //    //    .WithMany(d => d.turns)
        //    //    .HasForeignKey(t => t.doctorid)
        //    //    .OnDelete(DeleteBehavior.Restrict); // הגבלת מחיקה

        //    //modelBuilder.Entity<Doctor>()
        //    //    .HasOne(d => d.user)
        //    //    .WithMany() // או WithOne אם זה 1:1
        //    //    .HasForeignKey(d => d.UserId)
        //    //    .OnDelete(DeleteBehavior.Restrict); // הגבלת מחיקה

        //    modelBuilder.Entity<User>(b =>
        //    {
        //        b.Property(e => e.Role)
        //            .HasConversion(
        //                v => v.ToString(), // המרה לstring
        //                v => Enum.Parse<eRole>(v)); // המרה חזרה לenum
        //    });
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassDoctor>()
                .HasOne(c => c.User)
                .WithMany() // או WithOne אם זה 1:1
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict); // הגבלת מחיקה

            modelBuilder.Entity<ClassPatient>()
               .HasOne(c => c.User)
               .WithMany() // או WithOne אם זה 1:1
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.Restrict); // הגבלת מחיקה


            modelBuilder.Entity<ClassRoute>()
                .HasOne(t => t.doctor)
                .WithMany(d => d.Routes)
                .HasForeignKey(t => t.doctorId)
                .OnDelete(DeleteBehavior.Restrict); // הגבלת מחיקה

            modelBuilder.Entity<ClassRoute>()
             .HasOne(t => t.patient)
             .WithMany(d => d.Routes)
             .HasForeignKey(t => t.patientId)
             .OnDelete(DeleteBehavior.Restrict); // הגבלת מחיקה

            modelBuilder.Entity<User>(b =>
            {
                b.Property(e => e.Role)
                    .HasConversion(
                        v => v.ToString(), // המרה לstring
                        v => Enum.Parse<eRole>(v)); // המרה חזרה לenum
            });
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // הגדרת אילוץ המפתח החיצוני בין ClassDoctor ל-User
        //    modelBuilder.Entity<ClassDoctor>()
        //        .HasOne(d => d.User)
        //        .WithMany()
        //        .HasForeignKey(d => d.UserId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // הגדרת אילוץ המפתח החיצוני בין ClassPatient ל-User
        //    modelBuilder.Entity<ClassPatient>()
        //        .HasOne(p => p.User)
        //        .WithMany()
        //        .HasForeignKey(p => p.UserId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // הגדרת אילוץ המפתח החיצוני בין ClassRoute ל-ClassDoctor ו-ClassPatient
        //    modelBuilder.Entity<ClassRoute>()
        //        .HasOne(r => r.doctor)
        //        .WithMany(d => d.Routes)
        //        .HasForeignKey(r => r.doctorId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<ClassRoute>()
        //        .HasOne(r => r.patient)
        //        .WithMany(p => p.Routes)
        //        .HasForeignKey(r => r.patientId)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}

    }

}
