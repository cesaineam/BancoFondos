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
        public async Task<FondosInfo> ObtenerPorIdAsync(int id)
        {
            return await _context.FondosInfos.FindAsync(id);
        }
        public async Task<Fondo> ObtenerFondoPorIdAsync(int id)
        {
            return await _context.Fondos.FindAsync(id);
        }
        public async Task ActualizarAsync(Fondo fondo)
        {
            _context.Fondos.Update(fondo);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Fondo>> ObtenerFondosPorClienteIdAsync(int clienteId)
        {
            // Consulta a la tabla de transacciones y relaciónala con los fondos
            var fondos = await _context.Transacciones
                .Where(t => t.ClienteId == clienteId)
                .Select(t => t.Fondo)  
                .Distinct()             
                .ToListAsync();

            return fondos;
        }
    }
}
