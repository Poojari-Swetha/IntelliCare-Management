using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Domain.Enums;
namespace IntelliCareManagement.Domain.Entities
{


    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public int RoleID { get; set; }
        public int? PatientID { get; set; }
        public int? DoctorID { get; set; }
        public string Email { get; set; }

        // Navigation properties
        public Role Role { get; set; }
        public PatientProfile PatientProfile { get; set; }
        public Doctor Doctor { get; set; }
        public ICollection<UserSecurity> UserSecurities { get; set; }
    }


}
