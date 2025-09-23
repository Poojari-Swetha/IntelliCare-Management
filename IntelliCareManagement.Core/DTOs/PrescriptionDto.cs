using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliCareManagement.Core.DTOs
{
    
        public class PrescriptionDto
        {
            public int PrescriptionID { get; set; }
            public int ConsultationID { get; set; }
            public string Medication { get; set; }
            public string Dosage { get; set; }
            public string Duration { get; set; }
            public string PharmacyName { get; set; }
            public string PharmacyStatus { get; set; }
            public DateTime? DeliveryETA { get; set; }
        }
    

}
