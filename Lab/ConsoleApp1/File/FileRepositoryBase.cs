namespace ConsoleApp1.File;

public abstract class FileRepositoryBase<T>
    where T : IEntity
{
    private FileData<T> _data;
    private IList<T> _entities;

    public FileRepositoryBase(FileData<T> data)
    {
        _data = data;
    }

    public void Init()
    {
        if (_data.CheckFile())
        {
            readFromFile();
        }
        else
        {
            _entities = Create().ToArray();
            Commit();
        }
    }

    public virtual IEnumerable<T> Create()
    {
        var entities = new List<T>();
        return entities;
    }
    
    public IEnumerable<T> All()
    {
        readFromFile();
        return _entities;
    }

    public void Add(T entity)
    {
        setIndex(entity);
        _entities.Add(entity);
    }

    private void setIndex(T entity)
    {
        var index = _entities.Max(x => x.Id);
        entity.Id = index + 1;
    }

    public void Update(T entity)
    {
        var item = _entities.FirstOrDefault(x => x.Id == entity.Id);
        if (item != null)
        {
            _entities[_entities.IndexOf(item)] = entity;
        }
    }

    public void Remove(T entity)
    {
        var item = _entities.FirstOrDefault(x => x.Id == entity.Id);
        if (item != null)
        {
            _entities.Remove(entity);
        }
    }

    public void Commit()
    {
        _data.Write(_entities);
    }

    private void readFromFile()
    {
        _entities = _data.Read().ToList();
    }
}