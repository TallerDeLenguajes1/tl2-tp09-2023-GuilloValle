namespace repos;
using System.Data.SQLite;

public class TareasRepository : ItareasRepository
{   

    private string cadenaConexion = "Data Source=db/Kanban.db;Cache=Shared";
    public List<Tarea> GetAllTareasDeUnUsuario(int idUsuario){

            var queryString = @"SELECT * FROM Tareas WHERE id_usuario_asignado = @idUsuario;";
            List<Tarea> Tareas = new List<Tarea>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@idUsuario", idUsuario));
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tarea = new Tarea();
                        tarea.Id = Convert.ToInt32(reader["id"]);
                        tarea.IdUsuarioAsingnado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        tarea.Id = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["Nombre"].ToString();
                        tarea.Descripcion = reader["Descripcion"].ToString();
                        tareas.Add(tarea);
                    }
                }
                connection.Close();
            }
            return tareas;
    }
    public List<Tarea> GetAllTareasDeUnTablero(int idTablero);
}