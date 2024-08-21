using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoFondos.Application.DTOs.OutputDTOs
{
    public class ResultadoTransaccionDto
    {
        public bool EsExitoso { get; set; }
        public string Mensaje { get; set; }

    }
}
