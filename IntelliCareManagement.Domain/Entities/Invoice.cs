using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Domain.Enums;
namespace IntelliCareManagement.Domain.Entities
{

    public class Invoice
    {
        public int InvoiceID { get; set; }
        public int PatientID { get; set; }
        public decimal Amount { get; set; }
        public string InsuranceProvider { get; set; }
        public string Status { get; set; }
        public string ClaimStatus { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public DateTime? ApprovalDate { get; set; }

        // Navigation property
        public PatientProfile PatientProfile { get; set; }
    }


}
