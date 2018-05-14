using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompShop.Domain.Entities
{
    public class User
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
    }
}
