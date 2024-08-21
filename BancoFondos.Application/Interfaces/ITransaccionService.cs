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
    public interface ITransaccionService
    {
        TransaccionOutputDto CrearTransaccion(InsertarTransaccionInputDto transaccion);
        IEnumerable<Transaccion> ObtenerTransaccionesPorCliente(Guid clienteId);
    }
}
