using BancoFondos.Core.Entidades;
using BancoFondos.Core.Repositorios;
using BancoFondos.EntityFramework.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoFondos.EntityFramework.Fondos.Repositorios
{
    public class FondoRepositorio : IFondoRepositorio
    {
        private readonly BancoFondosDbContext _context;
        public FondoRepositorio(BancoFondosDbContext context) 
        {
            _context = context;
        }
        public async Task<Fondo> InsertarFondoAsync(Fondo fondo)
        {
            _context.Fondos.Add(fondo);
            await _context.SaveChangesAsync();
            return fondo;
        }
    }
}
