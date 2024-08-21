using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoFondos.Core.Entidades
{
    public class Fondo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
       
        public decimal Rendimiento { get; set; }
        public string Estado { get; set; }

        public ICollection<Transaccion> Transacciones { get; set; }
    }
}