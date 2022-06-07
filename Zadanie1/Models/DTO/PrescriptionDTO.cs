using System;
using System.Collections.Generic;

namespace Zadanie1.Models.DTO
{
    public class PrescriptionDTO
    {
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public PatientDTO Patient { get; set; }
        public DoctorDTO Doctor { get; set; }
        public virtual IEnumerable<MedicamentDTO> Medicaments { get; set; }
    }
}
