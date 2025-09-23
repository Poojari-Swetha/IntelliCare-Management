using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IntelliCareManagement.Domain.Entities
{
    public class PatientProfile
    {
        [Key]
        public int PatientID { get; set; } // EF will treat this as the primary key by convention

        public string Name { get; set; }
        public DateTime? DOB { get; set; }
        public string ContactInfo { get; set; }
        public string InsuranceDetails { get; set; }
        public string MedicalHistory { get; set; }

        // Navigation properties
        public User User { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Consultation> Consultations { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
