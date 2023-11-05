using repos;
using System.Data.SQLite;


public class UsuarioRepository : IUsuarioRepository
{

    private string cadenaConexion = "Data Source=db/Kanban.db;Cache=Shared";
    public List<Usuario> GetAll(){

         var queryString = @"SELECT * FROM Usuario;";
            List<Usuario> directores = new List<Usuario>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var usuario = new Usuario();
                        director.Id = Convert.ToInt32(reader["id"]);
                        director.Name = reader["name"].ToString();
                        director.Gender = Convert.ToInt32(reader["gender"]);
                        director.Uid = Convert.ToInt32(reader["uid"]);
                        directores.Add(director);
                    }
                }
                connection.Close();
            }
            return directores;
    }
}