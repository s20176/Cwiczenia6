using Microsoft.EntityFrameworkCore;
using System;

namespace Zad1.Models
{
    public class MainDbContext: DbContext
    {
        protected MainDbContext()
        {

        }

        public MainDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Prescription_Medicament>(p =>
            {
                p.HasKey(e => new
                {
                    e.IdMedicament,
                    e.IdPrescription
                });
            });

            modelBuilder.Entity<Patient>(p =>
            {
                p.HasData(
                    new Patient { IdPatient=1, FirstName="Jan", LastName="Kowalski", BirthDate=DateTime.Parse("2000-01-01")},
                    new Patient { IdPatient = 2, FirstName = "Jan", LastName = "Nowak", BirthDate = DateTime.Parse("2006-01-01") }
                    );
            });

            modelBuilder.Entity<Doctor>(p =>
            {
                p.HasData(
                    new Doctor { IdDoctor = 1, FirstName = "Jan", LastName = "Kowalski", Email="a@wp.pl" },
                    new Doctor { IdDoctor = 2, FirstName = "Jan", LastName = "Nowak", Email="b@o2.pl" }
                    );
            });

            modelBuilder.Entity<Medicament>(p =>
            {
                p.HasData(
                    new Medicament { IdMedicament = 1, Name = "Med1", Description = "desc1", Type = "type1" },
                    new Medicament { IdMedicament = 2, Name = "Med2", Description = "desc2", Type = "type2" }
                    );
            });

            modelBuilder.Entity<Prescription>(p =>
            {
                p.HasData(
                    new Prescription { IdPrescription = 1, Date = DateTime.Parse("2022-06-01"), DueDate = DateTime.Parse("2022-07-01"), IdPatient = 1, IdDoctor=1 },
                    new Prescription { IdPrescription = 2, Date = DateTime.Parse("2022-06-03"), DueDate = DateTime.Parse("2022-07-03"), IdPatient = 2, IdDoctor = 2 }
                    );
            });

            modelBuilder.Entity<Prescription_Medicament>(p =>
            {
                p.HasData(
                    new Prescription_Medicament { IdMedicament=1, IdPrescription = 1, Dose = 2, Details = "details1" },
                    new Prescription_Medicament { IdMedicament = 2, IdPrescription = 2, Dose = 3, Details = "details2" }
                    );
            });


        }
    }
}
