using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SociosWeb.DATA.Repositorio;
using SociosWeb.MODEL;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System.Linq;


namespace SociosWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocioController : Controller
    {
        private readonly ISocioRepositorio _socioRepositorio;
        private readonly IWebHostEnvironment _hostEnvironment;
 



        public SocioController(ISocioRepositorio socioRepositorio, IWebHostEnvironment hostEnvironment)
        {
            _socioRepositorio = socioRepositorio;
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> TodosSocios()
        {
            return Ok(await _socioRepositorio.TodosSocios());
        }
        [HttpGet("{nrosocio}")]
        public async Task<IActionResult> VerSocio(int nrosocio)
        {
            var socioq = await _socioRepositorio.VerSocio(nrosocio);
            socioq.ImageSrc = String.Format("{0}://{1}{2}/Images/{3}",Request.Scheme,Request.Host,Request.PathBase,socioq.foto);
            return Ok(socioq);
            



        }
        [HttpPost]
        public async Task<IActionResult> InsertarSocio([FromForm] Socio socio)
        {
           socio.foto = await SaveImage(socio.imageFile);
            if (socio == null)

                return BadRequest();

            
            var created = await _socioRepositorio.InsertarSocio(socio);

            return Created("created", created);
        }

        [NonAction]
        private async Task<string> SaveImage(IFormFile imageFile)
        {

            string foto = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            foto = foto + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", foto);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);

            }
            return foto;
        }

        [HttpPut]
        public async Task<IActionResult> ModificarSocio([FromBody] Socio socio)
        {
            if (socio == null)

                return BadRequest();


            var created = await _socioRepositorio.ModificarSocio(socio);

            return NoContent();
        }
        [HttpDelete("{nrosocio}")]
        public async Task<IActionResult> BorrarSocio(int nrosocio)
        {
            await _socioRepositorio.BorrarSocio(new Socio { nrosocio = nrosocio });

            return NoContent();
        }



    }
}
