using repos;


public class UsuarioRepository : IUsuarioRepository
{
    public List<Usuario> GetAll(){

         var queryString = @"SELECT * FROM Usuario;";
            List<Director> directores = new List<Usuario>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var director = new Director();
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