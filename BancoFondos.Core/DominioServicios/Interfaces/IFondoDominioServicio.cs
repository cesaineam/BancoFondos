using BancoFondos.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoFondos.Core.DominioServicios.Interfaces
{
    public interface IFondoDominioServicio
    {
        Task<ResultadoTransaccion> SuscribirTransaccionAsync(Transaccion transaccion);
        Task<List<Transaccion>> GetHistorialTransaccionesAsync(int clienteId);

    }
}
