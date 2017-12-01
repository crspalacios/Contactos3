using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contactos3.Backend.Models
{
    using Domain;
    public class DataContextLocal : DataContext
    {
        public System.Data.Entity.DbSet<Contactos3.Domain.Models.Perfil> Perfils { get; set; }

        public System.Data.Entity.DbSet<Contactos3.Domain.Models.Url> Urls { get; set; }

        public System.Data.Entity.DbSet<Contactos3.Domain.Models.Phone> Phones { get; set; }

        public System.Data.Entity.DbSet<Contactos3.Domain.Models.Address> Addresses { get; set; }

        public System.Data.Entity.DbSet<Contactos3.Domain.Models.Social> Socials { get; set; }

        public System.Data.Entity.DbSet<Contactos3.Domain.Models.Email> Emails { get; set; }

        public System.Data.Entity.DbSet<Contactos3.Domain.Models.Job> Jobs { get; set; }

        public System.Data.Entity.DbSet<Contactos3.Domain.Models.Brouchure> Brouchures { get; set; }
    }
}