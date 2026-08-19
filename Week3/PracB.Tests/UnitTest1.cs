public class EmployeeTests
{
    [Fact]
    public void FullTimeEmployeeCalculatePayTest()
    {
        FullTimeEmployee employee = new FullTimeEmployee();

        employee.Name = "Peter";
        employee.AnnualSalary = 1000m;

        decimal result = employee.CalculatePay();

        Assert.Equal(800m, result);
    }

    [Fact]
    public void ContractorCalculatePayTest()
    {
        Contractor contractor = new Contractor();

        contractor.Name = "Max";
        contractor.Rate = 50m;
        contractor.Hours = 10m;

        decimal result = contractor.CalculatePay();

        Assert.Equal(400m, result);
    }

    [Fact]
    public void FullTimeEmployeeReportTest()
    {
        FullTimeEmployee employee = new FullTimeEmployee();

        employee.Name = "Jesus";
        employee.AnnualSalary = 1000m;

        string result = employee.GenerateReport();

        Assert.Contains("Jesus", result);
    }

    [Fact]
    public void ContractorReportTest()
    {
        Contractor contractor = new Contractor();

        contractor.Name = "Max";
        contractor.Rate = 50m;
        contractor.Hours = 10m;

        string result = contractor.GenerateReport();

        Assert.Contains("Max", result);
    }
}