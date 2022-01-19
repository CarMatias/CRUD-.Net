using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SociosWeb.DATA.Repositorio;
using SociosWeb.MODEL;
using System.Threading.Tasks;

namespace SociosWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly ISocioRepositorio _pagoRepositorio;
        public PagoController(ISocioRepositorio pagoRepositorio)
        {
            _pagoRepositorio = pagoRepositorio;
        }
        [HttpPost("{id}")]
        public async Task<bool> Pagar(int id)
        {

            return await _pagoRepositorio.Pagar(id);
            
        }
    }
}
