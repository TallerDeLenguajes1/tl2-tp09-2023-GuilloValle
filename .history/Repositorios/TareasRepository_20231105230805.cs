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

    public List<Tarea> CantidadTareasDeUnEstado(estado estado1){
        
            var queryString = @"SELECT * FROM Tareas WHERE estado = @estadoElegido;";
            List<Tarea> Tareas = new List<Tarea>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@estadoElegido", estado1));
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

    public void CrearNuevaTarea(Tarea tarea){

            var query = $"INSERT INTO Tareas (id_tablero,Nombre,estado,descripcion,color,id_usuario_asignado) VALUES (@id_tablero,@nombre,@estado,@Descp,@color,@id_usu_asignado)";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                //SQLiteCommand command = connection.CreateCommand(); Por que no puedo usar esta linea en bez de la de arriba, linea 62, como uso en ObtenerUsuarioPorId???

                command.Parameters.Add(new SQLiteParameter("@id_tablero", tarea.IdTablero));
                command.Parameters.Add(new SQLiteParameter("@nombre", tarea.Nombre));
                command.Parameters.Add(new SQLiteParameter("@estado", tarea.Estado));
                command.Parameters.Add(new SQLiteParameter("@Descp", tarea.Descripcion));
                command.Parameters.Add(new SQLiteParameter("@color", tarea.Color));

                command.ExecuteNonQuery();

                connection.Close();   
            }
        
    }


}