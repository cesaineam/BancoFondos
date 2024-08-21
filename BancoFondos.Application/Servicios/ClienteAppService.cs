using BancoFondos.Application.DTOs.InputDTOs;
using BancoFondos.Application.DTOs.OutputDTOs;
using BancoFondos.Application.Interfaces;
using BancoFondos.Core.Entidades;
using BancoFondos.Core.Repositorios;

namespace BancoFondos.Application.Servicios
{
    public class ClienteAppService : IClienteAppService
    {
        // Inyecta aquí cualquier servicio o dependencia necesaria
        // Por ejemplo, si necesitas un repositorio de clientes, podrías inyectarlo aquí.
         private readonly IClienteRepositorio _clienteRepositorio;

        // Constructor sin inyección de la propia interfaz
        public ClienteAppService(IClienteRepositorio clienteRepositorio)
        {

             _clienteRepositorio = clienteRepositorio;
        }

        public async Task<ResultadoTransaccionDto> InsertarClienteAsync(InsertarClienteInputDto clienteInputDto)
        {
            var cliente = new Cliente
            {
                Nombre = clienteInputDto.Nombre,
                Saldo = clienteInputDto.Saldo,
            };

            await _clienteRepositorio.InsertarClienteAsync(cliente);

            return new ResultadoTransaccionDto
            {
                EsExitoso = true,
                Mensaje = "Cliente insertado exitosamente"
            };
        }
    }
}
