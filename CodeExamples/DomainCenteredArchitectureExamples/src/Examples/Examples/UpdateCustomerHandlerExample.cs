namespace UpdateCustomerExample;

public class UpdateCustomerHandlerExample
{
    public Guid CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StreetAddress1 { get; set; }
    public string StreetAddress2 { get; set; }
    public string City { get; set; }
    public string StateOrProvince { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string HomePhone { get; set; }
    public string MobilePhone { get; set; }
    public string PrimaryEmailAddress { get; set; }
    public string SecondayEmailAddress { get; set; }
}

public class CustomerMM
{
    private ICustomerRepository customerRepo;

    public void UpdateCustomer(Guid customerId,
        string firstName, string lastName,
        string streetAddress1, string streetAddress2,
        string city, string stateOrProvince,
        string postalCode, string country,
        string homePhone, string mobilePhone,
        string primaryEmailAddress,
        string secondayEmailAddress)
    {
        UpdateCustomerHandlerExample updateCustomerHandlerExample = customerRepo.Get(customerId);
        if (updateCustomerHandlerExample == null)
        {
            throw new Exception($"Customer with ID {customerId} not found");
        }

        updateCustomerHandlerExample.FirstName = firstName;
        updateCustomerHandlerExample.LastName = lastName;
        updateCustomerHandlerExample.StreetAddress1 = streetAddress1;
        updateCustomerHandlerExample.StreetAddress2 = streetAddress2;
        updateCustomerHandlerExample.City = city;
        // ... etc
    }

    public void PartialUpdate(Guid customerId,
        string firstName, string lastName,
        string streetAddress1, string streetAddress2,
        string city, string stateOrProvince,
        string postalCode, string country,
        string homePhone, string mobilePhone,
        string primaryEmailAddress,
        string secondayEmailAddress)
    {
        UpdateCustomerHandlerExample updateCustomerHandlerExample = customerRepo.Get(customerId);
        if (updateCustomerHandlerExample == null) throw new Exception($"Customer with ID {customerId} not found");

        if (firstName != null)
        {
            updateCustomerHandlerExample.FirstName = firstName;
        }
        if (lastName != null)
        {
            updateCustomerHandlerExample.LastName = lastName;
        }

        if (streetAddress1 != null)
        {
            updateCustomerHandlerExample.StreetAddress1 = streetAddress1;
        }
        // .. etc
    }
}

internal interface ICustomerRepository
{
    UpdateCustomerHandlerExample Get(Guid id);
}