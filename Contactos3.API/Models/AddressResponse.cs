using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contactos3.API.Models
{
    public class AddressResponse
    {
        public int AddressId
        {
            get;
            set;
        }
        public string DescriptionAddress
        {
            get;
            set;
        }
        public string NameAddress
        {
            get;
            set;
        }
        public string Ubications
        {
            get;
            set;
        }
    }
}