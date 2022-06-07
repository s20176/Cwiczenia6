using System.Threading.Tasks;
using Zad1.Models;
using Zadanie1.Models.DTO;

namespace Zadanie1.Services
{
    public interface IDbService
    {
        public Task<Doctor> getDoctor(int id);
        public Task addDoctor(Doctor doctor);
        public Task removeDoctor(int id);
        public Task updateDoctor(int id,DoctorDTO dto);
        public Task<PrescriptionDTO> getPrescription(int id);
    }
}
