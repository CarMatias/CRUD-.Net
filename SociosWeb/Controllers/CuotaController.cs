using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SociosWeb.MODEL;
using System.Threading.Tasks;
using SociosWeb.DATA.Repositorio;
using System.Data;
using System.Collections;
using System;
using System.Linq;

namespace SociosWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuotaController : ControllerBase
    {
        private readonly ISocioRepositorio _cuotaRepositorio;
        public CuotaController(ISocioRepositorio cuotaRepositorio)
        {
            _cuotaRepositorio = cuotaRepositorio;
        }
        [HttpGet("{nrosocio}")]
        public async Task<IActionResult> VerCuota(int nrosocio)
        {
            return Ok(await _cuotaRepositorio.VerCuota(nrosocio));
        }
        [HttpPost("{monto}")]

        public async Task<IActionResult> generarCuota( int monto)
        {
            
            var solonum = await _cuotaRepositorio.TodosSocios();

            foreach (Socio so in solonum)
            {

                Cuota temp = new();

                temp.mes = DateTime.Now.ToString("MM-yyyy");
                temp.nrosocio = so.nrosocio;
                temp.monto = monto;
                temp.pago = false;
                
                _cuotaRepositorio.generarCuota(temp);
            }

            
            return Ok();

        }







    }  

        /* */
    }

