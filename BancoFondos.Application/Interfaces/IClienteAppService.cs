using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoFondos.Application.DTOs.InputDTOs;
using BancoFondos.Application.DTOs.OutputDTOs;


namespace BancoFondos.Application.Interfaces
{
    public interface IClienteAppService
    {
        Task<ResultadoTransaccionDto> InsertarClienteAsync(InsertarClienteInputDto clienteInputDto);


    }
}
