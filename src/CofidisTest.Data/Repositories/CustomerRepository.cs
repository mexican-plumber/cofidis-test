using CofidisTest.Data.Models;

namespace CofidisTest.Data.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly CofidistTestContext _context;

    public CustomerRepository(CofidistTestContext context)
    {
        _context = context;
    }

    //  Had to do this due to ambiguous reference when using FirstOrDefault
    private IQueryable<Customer> Customers => (IQueryable<Customer>)_context.Customers;

    public Customer? GetByNIF(string nif)
    {
        return Customers.FirstOrDefault(c => c.NIF == nif);
    }
}

public interface ICustomerRepository
{
    Customer? GetByNIF(string nif);
}