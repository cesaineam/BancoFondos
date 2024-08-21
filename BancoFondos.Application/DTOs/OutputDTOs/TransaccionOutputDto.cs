using BancoFondos.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoFondos.Application.DTOs.OutputDTOs
{
    public class TransaccionOutputDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int FondoId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Tipo { get; set; }  // Puede ser "Suscripcion" o "Retiro"

        public Cliente Cliente { get; set; }
        public Fondo Fondo { get; set; }
    }
}