using Microsoft.EntityFrameworkCore;

namespace CofidisTest.Data.Repositories;

public class CreditLimitRepository : ICreditLimitRepository
{
    private readonly CofidistTestContext _context;

    public CreditLimitRepository(CofidistTestContext context)
    {
        _context = context;
    }

    public decimal GetCreditLimit(decimal income)
    {
        //_context.Database.ExecuteSqlInterpolated($"EXEC GetCreditLimit {income}");

        //  For brevity we use hardcoded values rather than calling SP
        switch (income)
        {
            case < 1000:
                return 1000;
            case > 1000 and <= 2000:
                return 2000;
            case > 2000:
                return 5000;
        }

        return 0;
    }
}

public interface ICreditLimitRepository
{
    decimal GetCreditLimit(decimal income);

}