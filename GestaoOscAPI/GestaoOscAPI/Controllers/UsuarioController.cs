using GestaoOscAPI.Models.Entities;
using GestaoOscAPI.Models.Enums;
using GestaoOscAPI.Models.Requests;
using GestaoOscAPI.Models.Responses;
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

        var response = new UsuarioResponse 
        {
            Id = user.Id,
            Nome = user.Nome,
            Email = user.Email,
            Perfil = user.Perfil,
            Setor = user.Setor
        };

        return Ok(response);
    }

    [HttpGet("/usuarios/gerentes/{setor}")]
    public IActionResult BuscarGerentesPorSetor(Setor setor)
    {
        var gerentes = usuarioService.BuscarPorSetor(setor);

        var response = gerentes.Select(u => new UsuarioResponse
        {
            Id = u.Id,
            Nome = u.Nome,
            Email = u.Email,
            Perfil = u.Perfil,
            Setor = u.Setor
        }).ToList();

        return Ok(response);
    }

}

