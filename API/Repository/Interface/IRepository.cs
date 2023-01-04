using API.Models;

namespace API.Repository.Interface;

public interface IRepository<Entity, T> where Entity : class
{
    public IEnumerable<Entity> Get();
    public Entity Get(T nik);
    public int Insert(Entity entity);
    public int Update(Entity entity);
    public int Delete(T nik);
}
