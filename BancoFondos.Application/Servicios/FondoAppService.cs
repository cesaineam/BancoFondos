using BancoFondos.Application.DTOs.InputDTOs;
using BancoFondos.Application.DTOs.OutputDTOs;
using BancoFondos.Application.Interfaces;
using BancoFondos.Application.MapDtos;
using BancoFondos.Core.Entidades;
using BancoFondos.Core.DominioServicios.Interfaces;
using BancoFondos.Core.Repositorios;

namespace BancoFondos.Application.Servicios
{
    public class FondoAppService : IFondoService
    {
        
         private readonly IFondoDominioServicio _fondoDominioServicio;

        // Constructor sin inyección de la propia interfaz
        public FondoAppService(IFondoDominioServicio fondoDominioServicio)
        {

            _fondoDominioServicio = fondoDominioServicio;
        }

        public async Task<ResultadoTransaccionDto> SuscribirTransaccionAsync(InsertarTransaccionInputDto transaccionInputDto)
        {
            var transaccion = FondoMapper.TransaccionConvertirDtoAEntidad(transaccionInputDto);
            var resultadoTransaccion = await _fondoDominioServicio.SuscribirTransaccionAsync(transaccion);
            return FondoMapper.ResultadoTransaccionConvertirEntidadADto(resultadoTransaccion);
          
        }

        public async Task<List<TransaccionOutputDto>> GetHistorialTransaccionesAsync(int clienteId)
        {
            var transacciones = await _fondoDominioServicio.GetHistorialTransaccionesAsync(clienteId);
            return FondoMapper.ConvertirListaEntidadADto(transacciones);
        }

        public async Task<ResultadoTransaccionDto> MoverFondo(InsertarTransaccionInputDto transaccion, string tipoMovimiento)
        {
            var movimiento = FondoMapper.TransaccionConvertirDtoAEntidad(transaccion);
            var resultadoTransaccion = await _fondoDominioServicio.MoverFondo(movimiento, tipoMovimiento);
            return FondoMapper.ResultadoTransaccionConvertirEntidadADto(resultadoTransaccion);
        }
    }
}
