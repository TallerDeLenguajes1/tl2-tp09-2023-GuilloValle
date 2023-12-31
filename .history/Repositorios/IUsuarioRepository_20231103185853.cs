using repos;

public interface IUsuarioRepository
{
    public List<Usuario> GetAll();
    public Usuario GetById(int id);
    public void Create(Usuario usuario);
    public void Remove(int id);
    public void Update(Usuario usuario);
}