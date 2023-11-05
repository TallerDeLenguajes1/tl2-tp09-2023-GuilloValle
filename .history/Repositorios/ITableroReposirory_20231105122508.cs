namespace repos;

public interface ITableroReposirory
{
    public List<Tablero> GetAllTableros();

    public void CrearNuevoTablero();

    public void ModificarTablero(int id,Tablero tablero);


}