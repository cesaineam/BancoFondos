using BancoFondos.Core.Entidades;
using BancoFondos.Core.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoFondos.Core.DominioServicios.Interfaces;

namespace BancoFondos.Core.DominioServicios
{
    public class FondosDominioServicio : IFondoDominioServicio
    {
        private readonly IFondoRepositorio _fondoRepositorio;
        private readonly ITransaccionRepositorio _transaccionRepositorio;

        // Constructor sin inyección de la propia interfaz
        public FondosDominioServicio(IFondoRepositorio fondoRepositorio, ITransaccionRepositorio transaccionRepositorio)
        {

            _fondoRepositorio = fondoRepositorio;
            _transaccionRepositorio = transaccionRepositorio;
        }

        public async Task<ResultadoTransaccion> SuscribirTransaccionAsync(Transaccion transaccion)
        {
            var _transaccion = new Transaccion
            {
                Id = transaccion.Id,
                ClienteId = transaccion.ClienteId,
                FondoId= transaccion.FondoId,
                Fecha= transaccion.Fecha,
                Monto= transaccion.Monto,
                Tipo= transaccion.Tipo
            };

            await _transaccionRepositorio.InsertarTransaccionAsync(_transaccion);

            return new ResultadoTransaccion
            {
                EsExitoso = true,
                Mensaje = "Transaccion insertada exitosamente"
            };
        }
        public async Task<List<Transaccion>> GetHistorialTransaccionesAsync(int clienteId)
        {
            var transacciones = await _transaccionRepositorio.GetHistorialTransaccionesAsync(clienteId);
            return transacciones;
        }
    }
}
