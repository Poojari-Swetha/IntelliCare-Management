using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Domain.Enums;
namespace IntelliCareManagement.Domain.Entities
{


    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime Date_Time { get; set; }
        public string Status { get; set; }
        public int? QueuePosition { get; set; }
        public string QueueStatus { get; set; }

        // Navigation properties
        public PatientProfile PatientProfile { get; set; }
        public Doctor Doctor { get; set; }
        public ICollection<Consultation> Consultations { get; set; }
    }


}
