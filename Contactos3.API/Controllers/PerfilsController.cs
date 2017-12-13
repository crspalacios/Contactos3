
namespace Contactos3.API.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Contactos3.Domain;
    using Contactos3.Domain.Models;
    using System.Collections.Generic;
    using Contactos3.API.Models;

    [Authorize]
    public class PerfilsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Perfils
        public async Task<IHttpActionResult> GetPerfils()
        {
            var perfils = await db.Perfils.ToListAsync();
            var perfilsResponse = new List<PerfilResponse>();

            foreach(var perfil in perfils)
            {
                var addressResponse = new List<AddressResponse>();
                foreach (var address in perfil.Addresses)
                {
                    addressResponse.Add(new AddressResponse
                    {
                        AddressId = address.AddressId,
                        DescriptionAddress = address.DescriptionAddress,
                        NameAddress = address.NameAddress,
                        Ubications = address.Ubications,
                    });
                }
                var brouchureResponse = new List<BrouchureResponse>();
                foreach (var brouchure in perfil.Brouchures)
                {
                    brouchureResponse.Add(new BrouchureResponse
                    {
                        BrouchureId = brouchure.BrouchureId,
                        BrochureDescription = brouchure.BrochureDescription,
                        BrouchureImage = brouchure.BrouchureImage,
                        LastUpdate = brouchure.LastUpdate,
                    });
                }
                var emailResponse = new List<EmailResponse>();
                foreach (var email in perfil.Emails)
                {
                    emailResponse.Add(new EmailResponse
                    {
                        DescriptionEmail = email.DescriptionEmail,
                        EmailId = email.EmailId,
                        NameEmail = email.NameEmail,

                    });
                }
                var jobResponse = new List<JobResponse>();
                foreach (var job in perfil.Jobs)
                {
                    jobResponse.Add(new JobResponse
                    {
                        JobId = job.JobId,
                        JobCompany = job.JobCompany,
                        JobPosition = job.JobPosition,
                        LastUpdate = job.LastUpdate,
                    });
                }
                var phoneResponse = new List<PhoneResponse>();
                foreach (var phone in perfil.Phones)
                {
                    phoneResponse.Add(new PhoneResponse
                    {
                        PhoneId = phone.PhoneId,
                        DescriptionPhone = phone.DescriptionPhone,
                        PhoneNumber = phone.PhoneNumber,
                        LastUpdate = phone.LastUpdate,
                    });
                }
                var socialResponse = new List<SocialResponse>();
                foreach (var social in perfil.Socials)
                {
                    socialResponse.Add(new SocialResponse
                    {
                        SocialiD = social.SocialiD,
                        SocialDescription = social.SocialDescription,
                        SocialPerfil = social.SocialPerfil,
                    });
                }
                var urlResponse = new List<UrlResponse>();
                foreach (var url in perfil.Urls)
                {
                    urlResponse.Add(new UrlResponse
                    {
                        UrlId = url.UrlId,
                        DescriptionUrl = url.DescriptionUrl,
                        NameUrl = url.NameUrl,
                    });
                }


                perfilsResponse.Add(new PerfilResponse
                {

                    PerfilId = perfil.PerfilId,
                    Name = perfil.Name,
                    LastName = perfil.LastName,
                    ImagePerfil = perfil.ImagePerfil,
                    Phones  = phoneResponse,
                    Addresses = addressResponse,
                    Brouchures = brouchureResponse,
                    Emails = emailResponse,
                    Jobs = jobResponse,
                    Socials = socialResponse,
                    Urls = urlResponse,
     

                });
            }
            return Ok(perfilsResponse);
        }

        // GET: api/Perfils/5
        [ResponseType(typeof(Perfil))]
        public async Task<IHttpActionResult> GetPerfil(int id)
        {
            Perfil perfil = await db.Perfils.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }

            return Ok(perfil);
        }

        // PUT: api/Perfils/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPerfil(int id, Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != perfil.PerfilId)
            {
                return BadRequest();
            }

            db.Entry(perfil).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Perfils
        [ResponseType(typeof(Perfil))]
        public async Task<IHttpActionResult> PostPerfil(Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Perfils.Add(perfil);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = perfil.PerfilId }, perfil);
        }

        // DELETE: api/Perfils/5
        [ResponseType(typeof(Perfil))]
        public async Task<IHttpActionResult> DeletePerfil(int id)
        {
            Perfil perfil = await db.Perfils.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }

            db.Perfils.Remove(perfil);
            await db.SaveChangesAsync();

            return Ok(perfil);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PerfilExists(int id)
        {
            return db.Perfils.Count(e => e.PerfilId == id) > 0;
        }
    }
}