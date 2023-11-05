namespace repos;

public interface ITableroReposirory
{
    public List<Tablero> GetAllTableros();

    public Tablero CrearNuevoTablero();

    public void ModificarTablero(int id,Tablero tablero);

    public Tablero ObtenerTableroPorId(int id);


}