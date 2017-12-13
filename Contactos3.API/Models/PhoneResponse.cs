using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contactos3.API.Models
{
    public class PhoneResponse
    {
        public int PhoneId
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }
        public string DescriptionPhone
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