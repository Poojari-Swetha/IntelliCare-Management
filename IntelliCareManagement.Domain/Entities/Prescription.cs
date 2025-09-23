using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Domain.Enums;

namespace IntelliCareManagement.Domain.Entities
{
    public class Prescription
    {
        // Public properties
        public int PrescriptionID { get; set; }
        public int ConsultationID { get; set; }
        public string Medication { get; set; }
        public string Dosage { get; set; }
        public string Duration { get; set; }
        public string PharmacyName { get; set; }
        public string PharmacyStatus { get; set; }
        public DateTime? DeliveryETA { get; set; }

        // Navigation property
        public Consultation Consultation { get; set; }

        // Default constructor
        public Prescription()
        {
            // This empty constructor allows for creating an object without providing any initial data.
        }

        // Parameterized constructor for easy object initialization
        // This is a great way to ensure that key properties are set when the object is created.
        public Prescription(int consultationId, string medication, string dosage, string duration, string pharmacyName)
        {
            ConsultationID = consultationId;
            Medication = medication;
            Dosage = dosage;
            Duration = duration;
            PharmacyName = pharmacyName;
            // The other properties, like PharmacyStatus and DeliveryETA, can be set later.
        }
    }
}
