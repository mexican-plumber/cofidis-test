using CofidisTest.Application.Models;
using CofidisTest.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CofidisTest.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        private readonly ICreditService _creditService;

        public CreditController(ICreditService creditService)
        {
            _creditService = creditService;
        }

        [HttpPost]
        public CreditApplicationResponse Application(CreditApplicationRequest request)
        {
            return _creditService.CreditApplication(request.NIF, request.Amount);
        }
    }
}
