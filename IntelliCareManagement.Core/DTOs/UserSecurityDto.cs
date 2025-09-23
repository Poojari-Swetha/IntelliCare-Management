using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliCareManagement.Core.DTOs
{
    
        public class UserSecurityDto
        {
            public int SecurityID { get; set; }
            public int UserID { get; set; }
            public string OTPCode { get; set; }
            public DateTime? OTPExpiry { get; set; }
            public bool IsOTPVerified { get; set; }
            public string APIToken { get; set; }
            public DateTime? TokenExpiry { get; set; }
            public bool IsTokenActive { get; set; }
        }
    

}
