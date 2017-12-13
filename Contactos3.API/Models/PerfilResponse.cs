using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contactos3.API.Models
{
    public class PerfilResponse
    {

        public int PerfilId
        {

            get;
            set;
        }
        public string ImagePerfil
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }

        public List<AddressResponse> Addresses
        {
            get;
            set;
        }


        public List<JobResponse> Jobs
        {
            get;
            set;
        }

        public List<PhoneResponse> Phones
        {
            get;
            set;
        }

        public List<SocialResponse> Socials
        {
            get;
            set;
        }

        public List<UrlResponse> Urls
        {
            get;
            set;
        }

        public List<EmailResponse> Emails
        {
            get;
            set;
        }

        public List<BrouchureResponse> Brouchures
        {
            get;
            set;
        }

    }
}