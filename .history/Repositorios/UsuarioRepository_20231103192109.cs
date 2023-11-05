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
}