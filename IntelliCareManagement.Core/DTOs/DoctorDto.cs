using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliCareManagement.Core.DTOs
{
    
        public class DoctorDto
        {
            public int DoctorID { get; set; }
            public string Name { get; set; }
            public string Specialty { get; set; }
            public string ContactInfo { get; set; }
        }
    

}
