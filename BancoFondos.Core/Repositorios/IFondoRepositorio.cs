using BancoFondos.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoFondos.Core.Repositorios
{
    public interface IFondoRepositorio
    {        
          Task<Fondo> InsertarFondoAsync(Fondo fondo);
        Task<FondosInfo> ObtenerPorIdAsync(int id);
        Task ActualizarAsync(Fondo fondo);
        Task<Fondo> ObtenerFondoPorIdAsync(int id);
        Task<List<Fondo>> ObtenerFondosPorClienteIdAsync(int clienteId);

    }
}
