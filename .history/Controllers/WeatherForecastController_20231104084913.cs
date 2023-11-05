using Microsoft.AspNetCore.Mvc;
using repos;

namespace tl2_tp09_2023_GuilloValle.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    private UsuarioRepository usuarioRepositorio;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        usuarioRepositorio = new UsuarioRepository();
        var usu = usuarioRepositorio.GetAll();

        foreach (var item in usu)
        {
            System.Console.WriteLine(item.NombreDeUsuario);
        }
    }

    [HttpGet("/api/usuario")]
    public ActionResult<List<Usuario>> listarTodosLosUsuarios(int id){
        var listaUsuarios = usuarioRepositorio.GetAll();
        return Ok(listaUsuarios);
    }

    [HttpGet("/api/usuario/{Id}")]
    public ActionResult<List<Usuario>> buscarUsuarioPorId(int id){
        var usuarioEncontrado = usuarioRepositorio.ObtenerUsuarioPorId(id);
        return Ok(usuarioEncontrado);
    }



}
