using GestaoOscAPI.Models;
using GestaoOscAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoOscAPI.Controllers;

[ApiController]
[Route("/auth")]

public class UsuarioController : ControllerBase
{
    private readonly UsuarioService usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        this.usuarioService = usuarioService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        Usuario? user = usuarioService.ValidarLogin(request.Email, request.Senha);
        
        if (user == null)
            return Unauthorized();

        return Ok(user);
    }

    [HttpGet("/usuarios/gerentes/{setor}")]
    public IActionResult BuscarGerentesPorSetor(Setor setor)
    {
        return Ok(usuarioService.BuscarPorSetor(setor));
    }

}

