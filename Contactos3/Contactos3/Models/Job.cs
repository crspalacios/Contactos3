using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contactos3.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public string JobCompany { get; set; }
        public string JobPosition { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
