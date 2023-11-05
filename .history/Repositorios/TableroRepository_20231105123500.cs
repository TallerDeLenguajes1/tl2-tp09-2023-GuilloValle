namespace repos;
using System.Data.SQLite;
public class TableroRepository : ITableroReposirory
{
    public List<Tablero> GetAllTableros();
}