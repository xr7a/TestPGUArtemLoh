using System.Data;

namespace Test.Repositories;

public class CarRepository
{
    private IDbConnection _connection;

    public CarRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
}