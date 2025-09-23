using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliCareManagement.Core.DTOs
{
    
        public class PatientDto
        {
            public int PatientID { get; set; }
            public string Name { get; set; }
            public DateTime? DOB { get; set; }
            public string ContactInfo { get; set; }
            public string InsuranceDetails { get; set; }
            public string MedicalHistory { get; set; }
        }
    

}
