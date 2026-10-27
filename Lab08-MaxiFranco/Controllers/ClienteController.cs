using Lab08_MaxiFranco.Models.DTO;
using Lab08_MaxiFranco.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_MaxiFranco.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClientService _clienteService;

    public ClienteController(IClientService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClienteDtos>>> GetAll()
    {
        var clientes = await _clienteService.GetAllAsync();

        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClienteDtos>> GetById(int id)
    {
        var clientes = await _clienteService.GetByIdAsync(id);

        if (clientes == null)
        {
            return NotFound();
        }

        return Ok(clientes);
    }

    [HttpPost]
    public async Task<ActionResult<ClienteDtos>> Create(
        ClienteDto dto)
    {
        var clientes = await _clienteService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = clientes.Clientid },
            clientes);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        ClienteDto dto)
    {
        var actualizado = await _clienteService.UpdateAsync(id, dto);

        if (!actualizado)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _clienteService.DeleteAsync(id);

        if (!eliminado)
        {
            return NotFound();
        }

        return NoContent();
    }
}