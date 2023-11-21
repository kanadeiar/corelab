using Newtonsoft.Json;

namespace ConsoleApp1.File;

public class FileData<T>
    where T : IEntity
{
    private readonly string _filename;
    private readonly string _catalog;
    private readonly string _pathToProfile;
    private readonly string _path;

    public FileData(string filename, string catalog, string? pathToProfile = null)
    {
        _filename = filename;
        _catalog = catalog;
        _pathToProfile = pathToProfile ?? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        _path = Path.Combine(_pathToProfile, _catalog, _filename);
        checkDirectory(_catalog, _pathToProfile);
    }

    private static void checkDirectory(string catalog, string pathToProfile)
    {
        var pathToCatalog = Path.Combine(pathToProfile, catalog);
        if (!Directory.Exists(pathToCatalog))
        {
            Directory.CreateDirectory(pathToCatalog);
        }
    }

    public IEnumerable<T> Read()
    {
        if (CheckFile())
        {
            var text = System.IO.File.ReadAllText(_path);
            var items = JsonConvert.DeserializeObject<IEnumerable<T>>(text);
            return items ?? new List<T>();
        }
        return new List<T>();
    }

    public bool CheckFile()
    {
        return System.IO.File.Exists(_path);
    }

    public void Write(IEnumerable<T> items)
    {
        var text = JsonConvert.SerializeObject(items, Formatting.Indented);
        System.IO.File.WriteAllText(_path, text);
    }
}