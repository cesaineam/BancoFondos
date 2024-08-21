using BancoFondos.Core.Entidades;
using BancoFondos.Core.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoFondos.Core.DominioServicios.Interfaces;
using System.Threading;

namespace BancoFondos.Core.DominioServicios
{
    public class FondosDominioServicio : IFondoDominioServicio
    {
        private readonly IFondoRepositorio _fondoRepositorio;
        private readonly ITransaccionRepositorio _transaccionRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;

        // Constructor sin inyección de la propia interfaz
        public FondosDominioServicio(IFondoRepositorio fondoRepositorio, ITransaccionRepositorio transaccionRepositorio,IClienteRepositorio clienteRepositorio)
        {

            _fondoRepositorio = fondoRepositorio;
            _transaccionRepositorio = transaccionRepositorio;
            _clienteRepositorio = clienteRepositorio;
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
        public async Task<ResultadoTransaccion> MoverFondo(Transaccion transaccion, string tipo)
        {
            Cliente cliente = await _clienteRepositorio.ObtenerPorIdAsync(transaccion.ClienteId);
            FondosInfo fondo = await _fondoRepositorio.ObtenerPorIdAsync(transaccion.FondoId);

            if (tipo == "Apertura")
            {
                if (transaccion.Monto <= cliente.Saldo && transaccion.Monto >= fondo.MontoMinimo)
                {
                    //Debitar saldo de cliente

                    cliente.Saldo -= transaccion.Monto;
                    await _clienteRepositorio.ActualizarAsync(cliente);


                    var _fondo = new Fondo
                    {
                        //Id = .Id,
                        Nombre = fondo.Nombre,
                        Rendimiento = transaccion.Monto,
                        Estado = "Activo"
                    };
                    //Crear Fondo
                    var fondoCreado = await _fondoRepositorio.InsertarFondoAsync(_fondo);
                    //Grabar transaccion
                    var _transaccion = await _transaccionRepositorio.InsertarTransaccionAsync(transaccion);

                }
                return new ResultadoTransaccion
                {
                    EsExitoso = true,
                    Mensaje = "Apertura exitosa"
                };
            }
            else
            {
                //DeshabilitarFondo
                var fondoConsulta = await _fondoRepositorio.ObtenerFondoPorIdAsync(transaccion.FondoId);
                if (fondoConsulta == null)
                {
                    return new ResultadoTransaccion
                    {
                        EsExitoso = false,
                        Mensaje = "No se encontro fondo"
                    }; ; // Fondo no encontrado
                }

                fondoConsulta.Estado = "Cancelado";
                await _fondoRepositorio.ActualizarAsync(fondoConsulta);

                //Debitar saldo a cliente 
                cliente.Saldo += transaccion.Monto;
                await _clienteRepositorio.ActualizarAsync(cliente);

                //Grabar transaccion

                var _transaccion = await _transaccionRepositorio.InsertarTransaccionAsync(transaccion);

                return new ResultadoTransaccion
                {
                    EsExitoso = true,
                    Mensaje = "Cancelacion exitosa"
                };

            }
            

        }
        public async Task<List<Fondo>> ObtenerFondosPorClienteIdAsync(int clienteId)
        {
            return await _fondoRepositorio.ObtenerFondosPorClienteIdAsync(clienteId);
        }

    }
}
