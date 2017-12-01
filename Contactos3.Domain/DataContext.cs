using System.Data.Entity;

namespace Contactos3.Domain
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }
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
