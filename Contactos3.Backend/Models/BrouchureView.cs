namespace Contactos3.Backend.Models
{
    using Contactos3.Domain.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    [NotMapped]
    public class BrouchureView : Brouchure
    {
        [Display(Name = "Image Perfil")]
        public HttpPostedFileBase ImageBrouchureFile { get; set; }
    }
}