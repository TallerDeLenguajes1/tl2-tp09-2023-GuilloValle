namespace repos;

public class TareasRepository : ItareasRepository
{
    public List<Tarea> GetAllTareasDeUnUsuario(int idUsuario){

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
                        tablero.Id_propietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                        tablero.Nombre = reader["Nombre"].ToString();
                        tablero.Descripcion = reader["Descripcion"].ToString();
                        tableros.Add(tablero);
                    }
                }
                connection.Close();
            }
            return tableros;
    }
    public List<Tarea> GetAllTareasDeUnTablero(int idTablero);
}