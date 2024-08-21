using BancoFondos.Application.DTOs.InputDTOs;
using BancoFondos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class FondosController : ControllerBase
{
    private readonly IClienteAppService _clienteAppService;
    private readonly IFondoService _fondoService;

    public FondosController(IClienteAppService clienteService, IFondoService fondoService)
    {
        _clienteAppService = clienteService;
        _fondoService = fondoService;
    }

    [HttpPost("insertar-cliente")]
    public async Task<IActionResult> InsertarCliente([FromBody] InsertarClienteInputDto clienteDto)
    {
        if (clienteDto == null)
        {
            return BadRequest("Datos de cliente inválidos.");
        }

        var cliente = await _clienteAppService.InsertarClienteAsync(clienteDto);

        return Ok(cliente);
    }

    [HttpPost("insertar-transaccion")]
    public async Task<IActionResult> InsertarTransaccion([FromBody] InsertarTransaccionInputDto transaccionDto)
    {
        if (transaccionDto == null)
        {
            return BadRequest("Datos de transaccion inválidos.");
        }

        var transaccion = await _fondoService.SuscribirTransaccionAsync(transaccionDto);

        return Ok(transaccion);
    }
    [HttpGet("Historial/{clienteId}")]
    public async Task<IActionResult> GetHistorialTransacciones(int clienteId)
    {
        var historialTransacciones = await _fondoService.GetHistorialTransaccionesAsync(clienteId);
        return Ok(historialTransacciones);
    }
    [HttpGet("MoverFondo")]
    public async Task<IActionResult> MoverFondo([FromBody] InsertarTransaccionInputDto transaccionDto,string tipoMovimiento)
    {
        if (transaccionDto == null)
        {
            return BadRequest("Datos de transaccion inválidos.");
        }
   
        var movimiento = await _fondoService.MoverFondo(transaccionDto, tipoMovimiento);
        return Ok(movimiento);
    }
    [HttpGet("ObtenerFondosxId/{clienteId}")]
    public async Task<IActionResult> ObtenerFondosxId(int clienteId)
    {
        var fondos = await _fondoService.ObtenerFondosPorClienteIdAsync(clienteId);

        if (fondos == null || fondos.Count == 0)
        {
            return NotFound("No se encontraron fondos para este usuario.");
        }

        return Ok(fondos);
    }
}
