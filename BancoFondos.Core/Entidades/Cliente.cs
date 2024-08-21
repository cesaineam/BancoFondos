using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoFondos.Core.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public decimal Saldo { get; set; }

        public ICollection<Transaccion> Transacciones { get; set; }

    }
}
