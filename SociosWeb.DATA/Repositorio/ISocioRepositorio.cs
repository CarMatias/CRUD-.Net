using SociosWeb.MODEL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociosWeb.DATA.Repositorio
{
    public interface ISocioRepositorio
    {
        Task<IEnumerable<Socio>> TodosSocios();
        Task<Socio> VerSocio(int nrosocio);
        Task<bool> InsertarSocio(Socio socio);

        Task<bool> ModificarSocio(Socio socio);
        Task<bool> BorrarSocio(Socio socio);
        Task<IEnumerable> VerCuota( int nrosocio);
        Task<bool> generarCuota(Cuota cuota);
        Task<bool> Pagar(int id);


    }
}
    