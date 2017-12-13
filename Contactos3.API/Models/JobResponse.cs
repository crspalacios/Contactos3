using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contactos3.API.Models
{
    public class JobResponse
    {
        public int JobId
        {
            get;
            set;
        }

        public string JobCompany
        {
            get;
            set;
        }
        public string JobPosition
        {
            get;
            set;
        }
        public DateTime LastUpdate
        {
            get;
            set;
        }
    }
}