using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contactos3.API.Models
{
    public class BrouchureResponse
    {
        public int BrouchureId
        {
            get;
            set;
        }

        public string BrouchureImage
        {
            get;
            set;
        }
        public string BrochureDescription
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