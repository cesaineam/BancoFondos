using BancoFondos.Core.Entidades;
using BancoFondos.Core.Repositorios;
using BancoFondos.EntityFramework.Db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoFondos.EntityFramework.Fondos.Repositorios
{
    
    public class TransaccionRepositorio : ITransaccionRepositorio
    {
        private readonly BancoFondosDbContext _context;
        
        public TransaccionRepositorio(BancoFondosDbContext context)
        {
            _context = context;
        }
        public async Task<Transaccion> InsertarTransaccionAsync(Transaccion transaccion)
        {
            _context.Transacciones.Add(transaccion);
            await _context.SaveChangesAsync();
            return transaccion;
        }

        public async Task<List<Transaccion>> GetHistorialTransaccionesAsync(int clienteId)
        {
            return await _context.Transacciones
                                   .Where(t => t.ClienteId == clienteId)
                                   .ToListAsync();
        }
    }
}
