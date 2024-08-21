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
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BancoFondosDbContext _context;

        public ClienteRepositorio(BancoFondosDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> InsertarClienteAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

       
    }
}
