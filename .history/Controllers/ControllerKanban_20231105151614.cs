using Microsoft.AspNetCore.Mvc;
using repos;

namespace tl2_tp09_2023_GuilloValle.Controllers;

[ApiController]
[Route("[controller]")]
public class ControllerKanban : ControllerBase
{
    private readonly ILogger<ControllerKanban> _logger;

    private UsuarioRepository usuarioRepositorio;
    private TableroRepository tableroRepositorio;

    private TareasRepository tareaRepositorio;

    public ControllerKanban(ILogger<ControllerKanban> logger)
    {
        _logger = logger;
        usuarioRepositorio = new UsuarioRepository();
        tableroRepositorio = new TableroRepository();
        tareaRepositorio = new TareasRepository();
    }

    [HttpGet("/api/usuario")]
    public ActionResult<List<Usuario>> listarTodosLosUsuarios(int id){
        var listaUsuarios = usuarioRepositorio.GetAllUsuarios();
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

    [HttpPut("/api/tarea/{id}/")]
    public ActionResult modificarUsuario(int id,Usuario usuario){
        usuarioRepositorio.ModificarUsuario(id,usuario);
        return Ok();
    }


    /*--------------------------------------  TABLERO   ----------------------------------------------------*/

    [HttpGet("/api/tableros")]
    public ActionResult<List<Tablero>> listarTodosLosTableros(){
        var listaTableros = tableroRepositorio.GetAllTableros();
        return Ok(listaTableros);
    }
    
    [HttpPost("/api/Tablero")]

    public ActionResult<Tablero> crearTablero(Tablero tablero){
        tableroRepositorio.CrearNuevoTablero(tablero);
        return Ok(tablero);
    }


    /*-------------------------------- TAREAS ----------------------------------------------------*/

    [HttpGet("/api/Tarea/Usuario/{id}")]
    public ActionResult<List<Tarea>> listarTareasDeUnUsuario(int idUsuarioaaaaaaaaaaaaaaaaaaaaaaaa){
        var listaTareas = tareaRepositorio.GetAllTareasDeUnUsuario(idUsuario);
        return Ok(listaTareas);
    } 

}
