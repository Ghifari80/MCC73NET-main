using API.Contexts;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace API.Repository;

public class GeneralRepository<Entity, T> : IRepository<Entity, T> where Entity : class
{

    protected MyContext _context = null;
    private DbSet<Entity> _table = null;

    public GeneralRepository(MyContext context)
    {
        _context = context;
        _table = context.Set<Entity>();
    }

    public int Delete(T id)
    {
        var data = _table.Find(id);
        if (data == null)
        {
            return 0;
        }
        _table.Remove(data);
        var result = _context.SaveChanges();
        return result;
    }

    public IEnumerable<Entity> Get()
    {
        return _table.ToList();
    }

    public Entity Get(T id)
    {
        return _table.Find(id);
    }

    public int Insert(Entity entity)
    {
        _table.Add(entity);
        var result = _context.SaveChanges();
        return result;
    }

    public int Update(Entity entity)
    {
        _table.Entry(entity).State = EntityState.Modified;
        var result = _context.SaveChanges();
        return result;
    }
}
