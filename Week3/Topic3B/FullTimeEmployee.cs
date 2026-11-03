public class FullTimeEmployee : Employee, IReportable
{
    public decimal AnnualSalary { get; set; }

    public override decimal CalculatePay()
    {
        decimal tax = AnnualSalary * TaxRate;
        
        decimal AfterTax = AnnualSalary - tax;

        
        return AfterTax;
    }

    public string GenerateReport()
    {
        return $"Name: {Name}, Annual Salary: {AnnualSalary}, Pay after tax: {CalculatePay()}";
    }
}