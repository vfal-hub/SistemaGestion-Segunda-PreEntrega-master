using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness.Services;
using SistemaGestionEntities;

namespace SistemaGestionWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly ILogger<UsuariosController> _logger;
    private readonly UsuariosService _usuariosService;

    public UsuariosController(ILogger<UsuariosController> logger, UsuariosService usuariosService)
    {
        _logger = logger;
        _usuariosService = usuariosService;
    }

   
    [HttpGet(Name = "Get Usuarios")]
    public ActionResult<List<Usuario>> GetUsuarios([FromQuery(Name = "filtro")] string? filtro)
    {
        if (filtro == null)
        {
            return _usuariosService.ListUsers();
        }
        return _usuariosService.GetUserBy(filtro);
    }

    [HttpGet("{id}")]
    public ActionResult<Usuario> GetOneUser(int id)
    {     
        var usuario = _usuariosService.GetOneUser(id);
        if (usuario is null)
        {
            return NotFound();
        }
        return usuario;
    }

    [HttpPost]
    public ActionResult<Usuario> CreateUser([FromBody] Usuario usuario)
    {
        var usuarioCreado = _usuariosService.CreateUser(usuario);
        return CreatedAtAction(nameof(GetOneUser), new { id = usuarioCreado.Id }, usuario);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateUser([FromRoute(Name = "id")] int id, [FromBody] Usuario usuario)
    {
        _usuariosService.UpdateUser(id, usuario);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteUser([FromRoute(Name = "id")] int id)
    {
        _usuariosService.DeleteUser(id);
        return NoContent();
    }

}

