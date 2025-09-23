using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliCareManagement.Domain.Entities
{
    public class Consultation
    {
        public int ConsultationID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public int? AppointmentID { get; set; }
        public string Notes { get; set; }
        public string Diagnosis { get; set; }

        // Navigation properties
        public PatientProfile PatientProfile { get; set; }
        public Doctor Doctor { get; set; }
        public Appointment Appointment { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
    }


}
