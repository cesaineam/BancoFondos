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

    }
}
