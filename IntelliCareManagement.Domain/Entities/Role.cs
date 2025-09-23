using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliCareManagement.Domain.Entities
{


    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        // Navigation property
        public ICollection<User> Users { get; set; }
    }


}
