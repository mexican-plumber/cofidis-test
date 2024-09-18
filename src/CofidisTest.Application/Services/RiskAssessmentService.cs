using CofidisTest.Data.Models;

namespace CofidisTest.Application.Services;

public class RiskAssessmentService : IRiskAssessmentService
{
    public bool Validate(Customer customer, decimal amount)
    {
        //  todo: add logic to simulate market conditions
        return true;
    }
}

public interface IRiskAssessmentService
{
    bool Validate(Customer customer, decimal amount);
}