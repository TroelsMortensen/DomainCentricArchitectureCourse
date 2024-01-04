using DCAExamples.Core.Domain.Common.Exceptions;

namespace Examples;

public class Customer
{
    private string firstName;
    private string lastName;
    private string phoneNumber;
    private string email;

    public Customer(string firstName, string lastName, string phoneNumber, string email)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phoneNumber = phoneNumber;
        this.email = email;
    }

    private void stuff()
    {
        Customer c1 = new Customer("Mortensen", "12345678", "trmo@via.dk", "Troels");
        Customer c2 = new Customer("12345678", "trmo@via.dk", "Troels", "Mortensen");
        Customer c3 = new Customer("Mortensen", "12345678", "Troels", "trmo@via.dk");
    }
}

public class CustomerWithVOs
{
    private FirstName firstName;
    private LastName lastName;
    private PhoneNumber phoneNumber;
    private Email email;

    public CustomerWithVOs(FirstName firstName, LastName lastName, PhoneNumber phoneNumber, Email email)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phoneNumber = phoneNumber;
        this.email = email;
    }

    private void stuff()
    {
        FirstName firstName = new FirstName("Troels");
        LastName lastName = new LastName();
        Email email = new Email();
        PhoneNumber phoneNumber = new PhoneNumber();

        CustomerWithVOs c4 = new CustomerWithVOs(firstName, lastName, phoneNumber, email);
        // CustomerWithVOs c1 = new CustomerWithVOs(lastName, phoneNumber, email, firstName);
        // CustomerWithVOs c2 = new CustomerWithVOs(phoneNumber, email ,firstName, lastName);
        // CustomerWithVOs c3 = new CustomerWithVOs(lastName, phoneNumber, firstName, email);
    }
}

public class PhoneNumber
{
}

public class LastName
{
}

public class Email
{
}

public class FirstName
{
    public string Value { get; }

    public FirstName(string value)
    {
        Value = value;
        if (value is null)
            throw new InvalidArgumentException("Cannot be null");
        // more validation
    }
}