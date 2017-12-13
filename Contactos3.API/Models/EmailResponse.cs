using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contactos3.API.Models
{
    public class EmailResponse
    {
        public int EmailId
        {
            get;
            set;
        }

        public string DescriptionEmail
        {
            get;
            set;
        }
        public string NameEmail
        {
            get;
            set;
        }
    }
}