using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliCareManagement.Core.DTOs
{
    
        public class AppointmentDto
        {
            public int AppointmentID { get; set; }
            public int PatientID { get; set; }
            public int DoctorID { get; set; }
            public DateTime Date_Time { get; set; }
            public string Status { get; set; }
            public int? QueuePosition { get; set; }
            public string QueueStatus { get; set; }
        }
    

}
