
namespace Contactos3.Backend.Models
{
    using Domain.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    [NotMapped]
    public class PerfilView : Perfil
    {
        [Display(Name = "Image Perfil")]
        public HttpPostedFileBase ImagePerfilFile { get; set; }
    }
}