using System.Data;
using System.Data.Common;
using Test.Models;
using Npgsql;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace Test.Repositories;

public class CarRepository
{
    private DbConnection _connection;

    public CarRepository(DbConnection connection)
    {
        _connection = connection;
    }

    public async Task<ICollection<Car>> GetAll()
    {
        return (await _connection.QueryAsync<Car>("SELECT * FROM \"Cars\" ")).ToList();
    }
    public async Task<Car> GetCar(int id)
    {
        var cars = await _connection.QueryAsync<Car>("SELECT * FROM \"Cars\" WHERE id = @id", new { id });
        return cars.FirstOrDefault();
    }

    public void Add(Car car)
    {
        var sql = "INSERT INTO \"Cars\" (id, brand, model, yearofrelease, vincode) VALUES (@Id, @Brand, @Model, @YearOfRelease, @VinCode)";
        _connection.Execute(sql, car);
    }

    public void Update(Car car)
    {
        var sql =
            "UPDATE \"Cars\" SET brand = @Brand, model = @Model, yearofrelease = @YearOfRelease, vincode = @VinCode WHERE id = @Id";
        _connection.Execute(sql, car);
    }

    public void Delete(int Id)
    {
        _connection.Execute("DELETE FROM \"Cars\" WHERE id = @Id", new{Id});
    }
}