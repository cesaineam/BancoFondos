using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoFondos.Application.DTOs.InputDTOs
{
    public class InsertarTransaccionInputDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int FondoId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Tipo { get; set; }
    }
}
