using System.Data;
using System.Reflection;
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
        setColumnNames("Id", "Make", "Name", "Color");

        createSqlCommand(sql);
        using var reader = executeReader();
        initPositions(reader);
        while (reader.Read())
        {
            yield return new CarView(
                reader.GetInt32(first), 
                reader.GetString(next), 
                reader.GetString(next), 
                reader.GetString(next), 
                Array.Empty<byte>());
        }
    }

    public CarView? GetView(int carId)
    {
        var sql = @"SELECT i.Id, m.Name as Make, i.Name, i.Color 
                    FROM inventory i 
                    INNER JOIN makes m ON m.Id = i.MakeId
                    WHERE i.Id = @CarId";
        setColumnNames("Id", "Make", "Name", "Color");

        createSqlCommand(sql);
        addParameter("@CarId", DbType.Int32, carId, ParameterDirection.Input);
        using var reader = executeReader();
        initPositions(reader);
        if (reader.Read())
        {
            return new CarView(
                reader.GetInt32(first), 
                reader.GetString(next), 
                reader.GetString(next), 
                reader.GetString(next), 
                Array.Empty<byte>());
        }
        return null;
    }
    
    public Car? Get(int carId)
    {
        var sql = @"SELECT Id, MakeId, Name, Color 
                    FROM inventory
                    WHERE Id = @CarId";
        setColumnNames("Id", "MakeId", "Name", "Color");

        createSqlCommand(sql);
        addParameter("@CarId", DbType.Int32, carId, ParameterDirection.Input);
        using var reader = executeReader();
        initPositions(reader);
        if (reader.Read())
        {
            return new Car(
                reader.GetInt32(first), 
                reader.GetInt32(next), 
                reader.GetString(next), 
                reader.GetString(next), 
                Array.Empty<byte>());
        }
        return null;
    }

    public int Add(Car car)
    {
        var sql = $"INSERT INTO inventory (MakeId, Name, Color) Values (@MakeId, @Name, @Color) RETURNING Id";
        
        createSqlCommand(sql);
        addParameter("@MakeId", DbType.Int32, car.MakeId, ParameterDirection.Input);
        addParameter("@Name", DbType.String, car.Name, ParameterDirection.Input);
        addParameter("@Color", DbType.String, car.Color, ParameterDirection.Input);
        var result = executeScalar();
        return (int)result;
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