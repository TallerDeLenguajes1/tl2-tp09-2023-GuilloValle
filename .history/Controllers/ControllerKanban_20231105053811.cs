using Microsoft.AspNetCore.Mvc;
using repos;

namespace tl2_tp09_2023_GuilloValle.Controllers;

[ApiController]
[Route("[controller]")]
public class ControllerKanban : ControllerBase
{
    private readonly ILogger<ControllerKanban> _logger;

    private UsuarioRepository usuarioRepositorio;

    public ControllerKanban(ILogger<ControllerKanban> logger)
    {
        _logger = logger;
        usuarioRepositorio = new UsuarioRepository();
        /*var usu = usuarioRepositorio.GetAll();

        foreach (var item in usu)
        {
            System.Console.WriteLine(item.NombreDeUsuario);
        }*/
    }

    [HttpGet("/api/usuario")]
    public ActionResult<List<Usuario>> listarTodosLosUsuarios(int id){
        var listaUsuarios = usuarioRepositorio.GetAll();
        return Ok(listaUsuarios);
    }

    [HttpGet("/api/usuario/{id}")]
    public ActionResult<Usuario> buscarUsuarioPorId(int id){
        var usuarioEncontrado = usuarioRepositorio.ObtenerUsuarioPorId(id);
        return Ok(usuarioEncontrado);
    }

    [HttpPost("/api/Usuario")]
    public ActionResult<Usuario> crearUsuario(Usuario usuario){
        usuarioRepositorio.CrearNuevoUsuario(usuario);
        return Ok(usuario);
    }

    [HttpDelete("/api/usuario/{Id}")]

    public ActionResult<Usuario> eliminarUsuario(int id){
        usuarioRepositorio.EliminarUsuario(id);
        return Ok();
    }

}
