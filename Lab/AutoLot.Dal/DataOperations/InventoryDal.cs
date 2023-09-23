using System.Data;
using AutoLot.Dal.Models;

namespace AutoLot.Dal.DataOperations;

public class InventoryDal : DalBase
{
    public InventoryDal(string connectionString) : base(connectionString)
    {
    }
    
    public IEnumerable<CarView> GetAllView()
    {
        var sql = @"SELECT i.Id, m.Name as Make, i.Name, i.Color 
                    FROM inventory i 
                    INNER JOIN makes m ON m.Id = i.MakeId";
        
        createSqlCommand(sql);
        foreach (var carView in executeEnumerableReader()) 
            yield return carView;
    }

    public CarView? GetView(int id)
    {
        var sql = @"SELECT i.Id, m.Name as Make, i.Name, i.Color 
                    FROM inventory i 
                    INNER JOIN makes m ON m.Id = i.MakeId
                    WHERE i.Id = @CarId";
        
        createSqlCommand(sql);
        addParameter("@CarId", DbType.Int32, id, ParameterDirection.Input);
        return executeGetViewReader();
    }
    
    public Car? Get(int id)
    {
        var sql = @"SELECT Id, MakeId, Name, Color 
                    FROM inventory
                    WHERE Id = @CarId";

        createSqlCommand(sql);
        addParameter("@CarId", DbType.Int32, id, ParameterDirection.Input);
        return executeGetReader();
    }

    public void Add(Car car)
    {
        var sql = $"INSERT INTO inventory (MakeId, Name, Color) Values (@MakeId, @Name, @Color)";
        
        createSqlCommand(sql);
        addParameter("@MakeId", DbType.Int32, car.MakeId, ParameterDirection.Input);
        addParameter("@Name", DbType.String, car.Name, ParameterDirection.Input);
        addParameter("@Color", DbType.String, car.Color, ParameterDirection.Input);
        executeNonQuery();
    }
    
    public void Update(int id, Car car)
    {
        var sql = $"UPDATE inventory SET MakeId = @MakeId, Name = @Name, Color = @Color WHERE Id = {id}";

        createSqlCommand(sql);
        addParameter("@MakeId", DbType.Int32, car.MakeId, ParameterDirection.Input);
        addParameter("@Name", DbType.String, car.Name, ParameterDirection.Input);
        addParameter("@Color", DbType.String, car.Color, ParameterDirection.Input);
        executeNonQuery();
    }

    public void Delete(int id)
    {
        var sql = $"DELETE FROM inventory WHERE Id = @CarId";

        createSqlCommand(sql);
        addParameter("@CarId", DbType.Int32, id, ParameterDirection.Input);
        executeNonQuery();
    }
}