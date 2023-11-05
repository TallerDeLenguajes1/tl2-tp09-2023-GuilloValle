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

    [HttpGet("/api/usuario/{id}")] //por que es necesario poner la ruta asi si no el de tareas poniamos cualquier cosa
                                    //si pongo {Id} no funciona, I con mayuscula
    public ActionResult<Usuario> buscarUsuarioPorId(int id){
        var usuarioEncontrado = usuarioRepositorio.ObtenerUsuarioPorId(id);
        return Ok(usuarioEncontrado);
    }

    [HttpPost("/api/Usuario")]
    public ActionResult<Usuario> crearUsuario(Usuario usuario){
        usuarioRepositorio.CrearNuevoUsuario(usuario);
        return Ok(usuario);
    }

    [HttpDelete("/api/usuario/{id}")]

    public ActionResult eliminarUsuario(int id){ //que devolver aca? ActionResult<Usuario> esta bien?
        usuarioRepositorio.EliminarUsuario(id);
        return Ok();
    }

    [HttpPut("modificaUsuario")]
    public ActionResult modificarUsuario(int id,Usuario usuario){
        usuarioRepositorio.ModificarUsuario(id,usuario);
        return Ok();
    }
}
