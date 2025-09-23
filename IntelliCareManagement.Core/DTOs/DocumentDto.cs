using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliCareManagement.Core.DTOs
{
   
        public class DocumentDto
        {
            public int DocumentID { get; set; }
            public int PatientID { get; set; }
            public string DocumentType { get; set; }
            public string FilePath { get; set; }
        }
    

}
