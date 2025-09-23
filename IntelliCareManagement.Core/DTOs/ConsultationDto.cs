using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliCareManagement.Core.DTOs
{
    
        public class ConsultationDto
        {
            public int ConsultationID { get; set; }
            public int PatientID { get; set; }
            public int DoctorID { get; set; }
            public int? AppointmentID { get; set; }
            public string Notes { get; set; }
            public string Diagnosis { get; set; }
        }
    

}
