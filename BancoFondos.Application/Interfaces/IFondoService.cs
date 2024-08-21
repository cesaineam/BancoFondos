using BancoFondos.Application.DTOs.InputDTOs;
using BancoFondos.Application.DTOs.OutputDTOs;
using BancoFondos.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoFondos.Application.Interfaces
{
    public interface IFondoService
    {
        
        Task<ResultadoTransaccionDto> SuscribirTransaccionAsync(InsertarTransaccionInputDto transaccion);
        
        Task<List<TransaccionOutputDto>> GetHistorialTransaccionesAsync(int clienteId);

        Task<ResultadoTransaccionDto> MoverFondo(InsertarTransaccionInputDto transaccion, string tipoMovimiento);
        Task<List<FondoOutputDto>> ObtenerFondosPorClienteIdAsync(int clienteId);


    }
}
