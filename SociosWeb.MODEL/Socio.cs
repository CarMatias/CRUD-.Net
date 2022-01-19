using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
namespace SociosWeb.MODEL
{
    public class Socio
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int nrosocio { get; set; }
        public string direccion { get; set; }
        public long telefono { get; set; }
        public int dni { get; set; }
        public string foto { get; set; }

      [NotMapped]
        public IFormFile imageFile { get; set; }

      [NotMapped]
        public string ImageSrc { get; set; }

       }

    }

