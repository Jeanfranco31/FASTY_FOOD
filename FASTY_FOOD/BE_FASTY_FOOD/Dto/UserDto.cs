using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_FASTY_FOOD.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Identification { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string AddressDirection { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string RolName { get; set; } = null!;
        public bool Status { get; set; }
    }
}
