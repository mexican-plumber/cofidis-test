using CofidisTest.Application.Models;
using CofidisTest.Data.Models;
using CofidisTest.Data.Repositories;

namespace CofidisTest.Application.Services;

public class CreditService : ICreditService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICreditLimitRepository _creditLimitRepository;
    private readonly IRiskAssessmentService _riskAssessmentService;

    public CreditService(
        ICustomerRepository customerRepository, 
        ICreditLimitRepository creditLimitRepository, 
        IRiskAssessmentService riskAssessmentService)
    {
        _customerRepository = customerRepository;
        _creditLimitRepository = creditLimitRepository;
        _riskAssessmentService = riskAssessmentService;
    }

    public CreditApplicationResponse CreditApplication(string nif, decimal amount)
    {
        var customer = _customerRepository.GetByNIF(nif);
        if (customer == null)
        {
            return new CreditApplicationResponse();
        }

        return CreditApplication(customer, amount);
    }
    public CreditApplicationResponse CreditApplication(Customer customer, decimal amount)
    {
        var response = new CreditApplicationResponse
        {
            NIF = customer.NIF,
            Approved = false
        };

        var creditLimit = _creditLimitRepository.GetCreditLimit(customer.Income);

        //  Fail fast if credit amount requested higher than the stipulated credit limit
        if (creditLimit < amount)
        {
            return response;
        }

        response.Approved = _riskAssessmentService.Validate(customer, amount);

        return response;
    }
}

public interface ICreditService
{
    CreditApplicationResponse CreditApplication(string nif, decimal amount);
    CreditApplicationResponse CreditApplication(Customer customer, decimal amount);
}