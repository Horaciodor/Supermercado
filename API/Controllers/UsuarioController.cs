﻿using AutoMapper;
using Core._01_Services.Interfaces;
using Core._03_Entidades.DTO.Usuarios;
using Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Services;
using Core._03_Entidades.DTO;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;
    private readonly IMapper _mapper;

    public UsuarioController(IUsuarioService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("adicionar-usuario")]
    public void AdicionarAluno(Usuario usuarioDTO)
    {
        _service.Adicionar(usuarioDTO);
    }
    [HttpPost("fazer-login")]
    public Usuario FazerLogin(UsuarioLoginDTO usuarioLogin)
    {
        Usuario usuario = _service.FazerLogin(usuarioLogin);
        return usuario;
    }
    [HttpPost("Fazer-Login")]
    public Usuario FazerLogin(UsuarioLoginDTO usuariologin)
    {
        Usuario usuario = _service.FazerLogin(usuariologin);
        return usuario;
    }
    [HttpGet("listar-usuario")]
    public List<Usuario> ListarAluno()
    {
        return _service.Listar();
    }
    [HttpPut("editar-usuario")]
    public void EditarUsuario(Usuario p)
    {
        _service.Editar(p);
    }
    [HttpDelete("deletar-usuario")]
    public void DeletarUsuario(int id)
    {
        _service.Remover(id);
    }
}
