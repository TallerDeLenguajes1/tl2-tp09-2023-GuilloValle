using repos;
using System.Data.SQLite;


public class UsuarioRepository : IUsuarioRepository
{

    private string cadenaConexion = "Data Source=db/Kanban.db;Cache=Shared";
    public List<Usuario> GetAll(){

         var queryString = @"SELECT * FROM Usuario;";
            List<Usuario> usuarios = new List<Usuario>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(reader["id"]);
                        usuario.NombreDeUsuario = reader["Nombre_de_usuario"].ToString();
                        usuarios.Add(usuario);
                    }
                }
                connection.Close();
            }
            return usuarios;
    }

    public Usuario ObtenerUsuarioPorId(int id){

            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);  //Me conecto con la base de datos (en este caso Kanban.db)
            var usuario = new Usuario();
            SQLiteCommand command = connection.CreateCommand();  //creo un comando para poder hacer una consulta SQL
            command.CommandText = "SELECT * FROM Usuario WHERE id = @idUsu";
            command.Parameters.Add(new SQLiteParameter("@idUsu",id ));    // Lo que esta en @idUsu se reemplaza por lo que esta en id, se usa para evitar inyeccion de sql para no usar {}
            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())  //tiene sentido si solo trae un solo usuario la funcion?
                {
                    usuario.Id = Convert.ToInt32(reader["id"]);
                    usuario.NombreDeUsuario = reader["Nombre_de_usuario"].ToString();

                }
            }
            connection.Close();

            return (usuario);
    }


}