using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliCareManagement.Domain.Entities
{

    public class Doctor
    {
        public int DoctorID { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string ContactInfo { get; set; }

        // Navigation properties
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Consultation> Consultations { get; set; }
        public User User { get; set; }
    }


}
