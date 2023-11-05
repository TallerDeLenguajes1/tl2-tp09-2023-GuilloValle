namespace repos;

public interface ITableroReposirory
{
    public List<Tablero> GetAllTableros();

    public Tablero CrearNuevoTablero(Tablero tablero);

   /* public void ModificarTablero(int id,Tablero tablero);*/

    /*public Tablero ObtenerTableroPorId(int id);*/

   /* public List<Tablero> GetAllTablerosDeUsuarioEspecifico(int idUsuario);*/

   /* public void EliminarTablero(int id);*/
}