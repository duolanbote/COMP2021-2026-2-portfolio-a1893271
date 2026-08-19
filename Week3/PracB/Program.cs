FullTimeEmployee employee = new FullTimeEmployee();

employee.Name = "Peter";
employee.AnnualSalary = 80000m;

Console.WriteLine(employee.GenerateReport());
Console.WriteLine(employee.CalculatePay());

Contractor contractor = new Contractor();

contractor.Name = "Max";
contractor.Rate = 40m;
contractor.Hours = 100m;

Console.WriteLine(contractor.GenerateReport());
Console.WriteLine(contractor.CalculatePay());

Console.WriteLine(employee.GenerateReport());
Console.WriteLine("Calculate Pay: " + employee.CalculatePay());

Console.WriteLine();

Console.WriteLine(contractor.GenerateReport());
Console.WriteLine("Calculate Pay: " + contractor.CalculatePay());