using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliCareManagement.Core.DTOs
{
    
        public class UserDto
        {
            public int UserID { get; set; }
            public string Username { get; set; }
            public string PasswordHash { get; set; }
            public int RoleID { get; set; }
            public int? PatientID { get; set; }
            public int? DoctorID { get; set; }
            public string Email { get; set; }
        }
    

}
