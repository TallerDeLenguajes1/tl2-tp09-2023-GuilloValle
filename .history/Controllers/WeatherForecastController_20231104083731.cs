using Microsoft.AspNetCore.Mvc;
using repos;

namespace tl2_tp09_2023_GuilloValle.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        var UsuarioRepository = new UsuarioRepository();
        var usu = UsuarioRepository.GetAll();

        foreach (var item in usu)
        {
            System.Console.WriteLine(item.NombreDeUsuario);
        }
    }

    [HttpGet("/api/usuario")]

    public ActionResult<List<Usuario>> listarTodosLosUsuarios(int id){
        var tarea = manejoDeTareas.buscarTareaPorId(id);
        return Ok(tarea);
    }



}
