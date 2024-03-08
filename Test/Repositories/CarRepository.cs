using System.Data;
using Test.Models;
using Npgsql;
using Dapper;
namespace Test.Repositories;

public class CarRepository
{
    private IDbConnection _connection;

    public CarRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public ICollection<Car> GetAll()
    {
        return _connection.Query<Car>("SELECT * FROM \"Cars\" ").ToList();
    }
}