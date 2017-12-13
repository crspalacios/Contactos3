using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contactos3.Models
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public string PhoneNumber { get; set; }
        public string DescriptionPhone { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
