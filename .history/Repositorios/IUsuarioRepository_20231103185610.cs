using repos;

public interface IUsuarioRepository
{
    public List<> GetAll();
    public Usu GetById(int id);
    public void Create(Director director);
    public void Remove(int id);
    public void Update(Director director);
}