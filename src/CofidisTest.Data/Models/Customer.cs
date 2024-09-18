namespace CofidisTest.Data.Models;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NIF { get; set; }
    public decimal Income { get; set; }
    public int CreditRating { get; set; }
    public decimal CurrentMonthlyOutgoings { get; set; }
}