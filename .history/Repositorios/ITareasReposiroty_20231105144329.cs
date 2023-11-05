namespace repos;

public interface ItareasRepository
{
    public List<Usuario> GetAllUsuarios();
    public Usuario ObtenerUsuarioPorId(int id);
    public void CrearNuevoUsuario(Usuario usuario);
    public void EliminarUsuario(int id);
    public void ModificarUsuario(int id,Usuario usuario);
}