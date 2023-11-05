namespace repos;

public interface ItareasRepository
{
    public List<Usuario> GetAllUsuarios();
    public Usuario ObtenerUsuarioPorId(int id);
    public Tarea CrearNuevaTareaEnTablero(int idTablero);
    public void EliminarUsuario(int id);
    public void ModificarUsuario(int id,Usuario usuario);
}