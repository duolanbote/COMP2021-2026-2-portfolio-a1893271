using System;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Age { get; set; }

    public Person(string firstName, string lastName, double age)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("First name and last name can't be empty");
        }

        if (age <= 0)
        {
            throw new ArgumentException("Age can't be less than 0");
        }

        FirstName = firstName.Trim();
        LastName = lastName.Trim();
        Age = age;
    }

    public string FullName()
    {
        return $"{LastName}, {FirstName}";
    }

    public bool IsAdult()
    {
        return Age >= 18;
    }
}
