using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoFondos.Application.DTOs.OutputDTOs
{
    public class ClienteOutputDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public decimal Saldo { get; set; }
    }
}
