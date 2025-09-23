using System;
using System.ComponentModel.DataAnnotations;

namespace IntelliCareManagement.Domain.Entities
{
    public class UserSecurity
    {
        [Key] // Explicitly mark SecurityID as the primary key
        public int SecurityID { get; set; }

        public int UserID { get; set; }
        public string OTPCode { get; set; }
        public DateTime? OTPExpiry { get; set; }
        public bool IsOTPVerified { get; set; }
        public string APIToken { get; set; }
        public DateTime? TokenExpiry { get; set; }
        public bool IsTokenActive { get; set; }

        // Navigation property
        public User User { get; set; }
    }
}
