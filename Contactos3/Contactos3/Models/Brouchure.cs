using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contactos3.Models
{
    public class Brouchure
    {
        public int BrouchureId { get; set; }
        public string BrouchureImage { get; set; }
        public string BrochureDescription { get; set; }
        public DateTime LastUpdate { get; set; }


        public string BrouchureImageFullPath
        {
            get
            {
                return string.Format("http://contactos3backend.azurewebsites.net/{0}", BrouchureImage.Substring(1));
            }
        }
    }
}
