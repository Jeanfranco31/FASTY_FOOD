using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_FASTY_FOOD.Dto
{
    public class RolDto
    {
        public int Id { get; set; }

        public string Rolname { get; set; } = null!;

        public DateTime? DateRegister { get; set; }

        public bool? StatusRol { get; set; }
    }
}
