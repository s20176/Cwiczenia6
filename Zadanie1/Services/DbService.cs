using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Zad1.Models;
using Zadanie1.Models.DTO;

namespace Zadanie1.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _mainDbContext;

        public DbService(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }
        public async Task<Doctor> getDoctor(int id)
        {
            return _mainDbContext.Doctors.Where(e => e.IdDoctor == id).FirstOrDefault();
            
        }

        public async Task removeDoctor(int id)
        {
            Doctor doctor = _mainDbContext.Doctors.Where(e => e.IdDoctor == id).FirstOrDefault();
            if (doctor == null)
            {
                throw new Exception("Nie znaleziono doktora");
            }
            _mainDbContext.Remove(doctor);
            await _mainDbContext.SaveChangesAsync();

        }

        public async Task addDoctor(Doctor doctor)
        {
            _mainDbContext.Add(doctor);
            await _mainDbContext.SaveChangesAsync();
        }

        public async Task updateDoctor(int id,DoctorDTO dto)
        {
            Doctor doctor = _mainDbContext.Doctors.Where(e => e.IdDoctor == id).FirstOrDefault();
            if (doctor == null)
            {
                throw new Exception("Nie znaleziono doktora");
            }
            doctor.FirstName = dto.FirstName;
            doctor.LastName = dto.LastName;
            doctor.Email = dto.Email;
            _mainDbContext.Attach(doctor);
            await _mainDbContext.SaveChangesAsync();
        }

        public async Task<PrescriptionDTO> getPrescription(int id)
        {
            PrescriptionDTO prescription = _mainDbContext.Prescriptions.Where(e => e.IdPrescription == id)
                .Select(e => new PrescriptionDTO
                {
                    Date=e.Date,
                    DueDate=e.DueDate,
                    Patient = new PatientDTO { FirstName=e.Patient.FirstName,LastName=e.Patient.LastName,BirthDate=e.Patient.BirthDate },
                    Doctor = new DoctorDTO { FirstName = e.Doctor.FirstName,LastName=e.Doctor.LastName,Email=e.Doctor.Email},
                    Medicaments =e.Prescription_Medicaments.Select(p=>new MedicamentDTO
                    {
                        Name=p.Medicament.Name,
                        Description=p.Medicament.Description,
                        Type=p.Medicament.Type
                    })
                }).FirstOrDefault();
            if (prescription == null)
            {
                throw new Exception("Recepta nie istnieje");
            }
            return prescription;
        }
    }
}
