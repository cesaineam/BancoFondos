using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoFondos.Core.Entidades
{
    public class FondosInfo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal MontoMinimo { get; set; }
        public string Categoria { get; set; }
    }
}
