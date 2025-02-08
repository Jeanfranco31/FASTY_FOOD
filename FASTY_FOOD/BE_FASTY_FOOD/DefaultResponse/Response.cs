using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_FASTY_FOOD.DefaultResponse
{
    public class Response
    {
        public CodeStatus code { get; set; }
        public string Message { get; set; } = null!;
        public Object Data { get; set; } = null!;

    }
}
