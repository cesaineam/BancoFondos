using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoFondos.Application.DTOs.InputDTOs
{
    public class InsertarClienteInputDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Saldo { get; set; }

    }
}
