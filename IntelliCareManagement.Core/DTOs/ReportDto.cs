using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliCareManagement.Core.DTOs
{
    // The ReportDto (Data Transfer Object) is used to send and receive data for the Report entity.
    public class ReportDto
    {
        public int ReportID { get; set; }
        public string Type { get; set; }
        public DateTime? GeneratedDate { get; set; }
        public string Metrics { get; set; }
        public string PredictionDetails { get; set; }
    }
}
