namespace repos;
using System.Data.SQLite;
public class TableroRepository : ITableroReposirory
{   

    private string cadenaConexion = "Data Source=db/Kanban.db;Cache=Shared";
    public List<Tablero> GetAllTableros(){

            var queryString = @"SELECT * FROM Tablero;";
            List<Tablero> tableros = new List<Tablero>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tablero = new Tablero();
                        tablero.Id = Convert.ToInt32(reader["id"]);
                        tablero.Nombre = reader["Nombre"].ToString();
                        tableros.Add(tablero);
                    }
                }
                connection.Close();
            }
            return usuarios;
    }
}