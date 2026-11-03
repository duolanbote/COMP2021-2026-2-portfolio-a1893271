using System;

namespace PracA.Tests;

public class PayrollTests
{
    [Fact]
    public void Constructor_SetsProperties()
    {
        Payroll payroll = new Payroll(38, 42.5m, 0.2m);

        Assert.Equal(38m, payroll.Hours);
        Assert.Equal(42.5m, payroll.Rate);
        Assert.Equal(0.2m, payroll.TaxRate);
    }

    [Fact]
    public void CalculateNetPay_ReturnsGrossMinusTax()
    {
        Payroll payroll = new Payroll(38, 42.5m, 0.2m);

        Assert.Equal(1292.00m, payroll.CalculateNetPay());
    }

    [Fact]
    public void ChangeTaxRate_ChangesNetPay()
    {
        Payroll payroll = new Payroll(38, 42.5m, 0.2m);

        payroll.ChangeTaxRate(0.3m);

        Assert.Equal(0.3m, payroll.TaxRate);
        Assert.Equal(1130.50m, payroll.CalculateNetPay());
    }

    [Fact]
    public void NegativeHours_Throws()
    {
        Assert.Throws<ArgumentException>(() => new Payroll(-1, 42.5m, 0.2m));
    }

    [Fact]
    public void NegativeRate_Throws()
    {
        Assert.Throws<ArgumentException>(() => new Payroll(38, -1m, 0.2m));
    }

    [Fact]
    public void NegativeTaxRate_Throws()
    {
        Assert.Throws<ArgumentException>(() => new Payroll(38, 42.5m, -0.2m));
    }
}
