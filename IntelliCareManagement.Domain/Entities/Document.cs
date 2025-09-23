using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliCareManagement.Domain.Entities
{

    public class Document
    {
        public int DocumentID { get; set; }
        public int PatientID { get; set; }
        public string DocumentType { get; set; }
        public string FilePath { get; set; }

        // Navigation property
        public PatientProfile PatientProfile { get; set; }
    }


}
