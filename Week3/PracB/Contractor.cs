public class Contractor : Employee, IReportable
{
    public decimal Rate { get; set; }

    public decimal Hours { get; set; }

    public override decimal CalculatePay()
    {
        decimal totalPay = Rate * Hours;
        decimal tax = totalPay * TaxRate;

        return totalPay - tax;
    }

    public string GenerateReport()
    {
        return $"Name: {Name}, Rate: {Rate}, Hours: {Hours}, Pay after tax: {CalculatePay()}";
    }
}