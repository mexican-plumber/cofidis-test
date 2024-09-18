using CofidisTest.Application.Services;
using CofidisTest.Data.Models;
using CofidisTest.Data.Repositories;
using Moq;

namespace CofidisTest.Application.Tests.Services
{
    public class CreditServiceTests
    {
        private ICreditService _creditService;
        private Mock<ICustomerRepository> _customerRepositoryMock;
        private Mock<ICreditLimitRepository> _creditLimitRespositoryMock;
        private Mock<IRiskAssessmentService> _riskAssessmentServiceMock;

        [SetUp]
        public void Setup()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _creditLimitRespositoryMock = new Mock<ICreditLimitRepository>();
            _creditLimitRespositoryMock.Setup(x => x.GetCreditLimit(It.IsAny<decimal>())).Returns(2000);
            _riskAssessmentServiceMock = new Mock<IRiskAssessmentService>();
            _riskAssessmentServiceMock.Setup(x => x.Validate(It.IsAny<Customer>(), It.IsAny<decimal>())).Returns(true);

            _creditService = new CreditService(_customerRepositoryMock.Object, _creditLimitRespositoryMock.Object, _riskAssessmentServiceMock.Object);
        }

        [Test]
        public void CreditApplication_ShouldReturnSuccess_WhenAllRequirementsMet()
        {
            //  Arrange
            var customer = new Customer
            {
                FirstName = "Joe",
                LastName = "Bloggs",
                NIF = "123456789",
                Income = 1500,
                CreditRating = 500,
                CurrentMonthlyOutgoings = 250
            };

            //  Act
            var actual = _creditService.CreditApplication(customer, 900);

            //  Assert
            Assert.That(actual.Approved);
        }
    }
}