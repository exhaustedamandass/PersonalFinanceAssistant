using Infrastructure.Data;

namespace Infrastructure.Seeds;

public class Seed
{
    private readonly DataContext _dataContext;

    public Seed(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public void SeedData()
    {
        throw new NotImplementedException();
    }
}