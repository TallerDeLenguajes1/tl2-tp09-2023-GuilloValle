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
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["Nombre"].ToString();
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.Estado = (estado)Convert.ToInt32(reader["estado"]);
                        Tareas.Add(tarea);
                    }
                }
                connection.Close();
            }
            return Tareas;
    }


    public List<Tarea> GetAllTareasDeUnTablero(int idTablero){
        var queryString = @"SELECT * FROM Tareas WHERE id_tablero = @idTablero;";
        List<Tarea> Tareas = new List<Tarea>();
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {

            SQLiteCommand command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));
            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var tarea = new Tarea();
                    tarea.Id = Convert.ToInt32(reader["id"]);
                    tarea.IdUsuarioAsingnado = Convert.ToInt32(reader["id_usuario_asignado"]);
                    tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                    tarea.Nombre = reader["Nombre"].ToString();
                    tarea.Descripcion = reader["descripcion"].ToString();
                    tarea.Color = reader["color"].ToString();
                    tarea.Estado = (estado)Convert.ToInt32(reader["estado"]);
                    Tareas.Add(tarea);
                }

            }
            connection.Close();
        }
        return Tareas;
 
 }


}