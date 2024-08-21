using BancoFondos.Application.DTOs.InputDTOs;
using BancoFondos.Application.DTOs.OutputDTOs;
using BancoFondos.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoFondos.Application.MapDtos
{
    public static class FondoMapper
    {
        // Método para convertir de DTO a Entidad
        public static Cliente ClienteConvertirDtoAEntidad(InsertarClienteInputDto dto)
        {
            return new Cliente
            {
                Nombre = dto.Nombre,
                Id = dto.Id,
                Saldo = dto.Saldo,
               
            };
        }
        public static ClienteOutputDto ClienteConvertirEntidadADto(Cliente cliente)
        {
            return new ClienteOutputDto
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Saldo = cliente.Saldo

                // Asigna otros campos según sea necesario
            };
        }

        // Método para convertir de Entidad a DTO
        public static FondoOutputDto FondoConvertirEntidadADto(Fondo fondo)
        {
            return new FondoOutputDto
            {
                Id = fondo.Id,
                Nombre = fondo.Nombre,
               
                Rendimiento = fondo.Rendimiento

                // Asigna otros campos según sea necesario
            };
        }
        public static Fondo FondoConvertirDtoAEntidad(InsertarFondoInputDto dto)
        {
            return new Fondo
            {
                Nombre = dto.Nombre,
                Id = dto.Id,
                Rendimiento = dto.Rendimiento
                

            };
        }
        public static TransaccionOutputDto TransaccionConvertirEntidadADto(Transaccion transaccion)
        {
            return new TransaccionOutputDto
            {
                Id = transaccion.Id,
                ClienteId = transaccion.ClienteId,
                FondoId = transaccion.FondoId,
                Fecha = transaccion.Fecha,
                Monto = transaccion.Monto,
                Tipo = transaccion.Tipo



                // Asigna otros campos según sea necesario
            };
        }
        public static Transaccion TransaccionConvertirDtoAEntidad(InsertarTransaccionInputDto dto)
        {
            return new Transaccion
            {
                Id = dto.Id,
                ClienteId = dto.ClienteId,
                FondoId = dto.FondoId,
                Fecha = dto.Fecha,
                Monto = dto.Monto,
                Tipo = dto.Tipo


            };
        }
        public static ResultadoTransaccionDto ResultadoTransaccionConvertirEntidadADto(ResultadoTransaccion resultado)
        {
            return new ResultadoTransaccionDto
            {
                EsExitoso = resultado.EsExitoso,
                Mensaje = resultado.Mensaje
               
                // Asigna otros campos según sea necesario
            };
        }

        public static List<TransaccionOutputDto> ConvertirListaEntidadADto(List<Transaccion> transacciones)
        {
            return transacciones.Select(TransaccionConvertirEntidadADto).ToList();
        }


    }
}
