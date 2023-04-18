namespace UbiquitousLanguageExamples;

public class Person
{
    private IPersonRepository personRepo;
    public string Name { get; set; }
    public string Email { get; set; }


    //...

    public void Update(string name, string email /*, ...*/)
    {
        if (!string.IsNullOrEmpty(name))
        {
            Name = name;
        }

        if (!string.IsNullOrEmpty(email))
        {
            Email = email;
        }

        //  ...
    }
    
    public void mymethod(int id, string newEmail)
    {
        
        Person p = personRepo.GetById(id);
        p.ChangeEmail(newEmail);


    }

    private void ChangeEmail(string newEmail)
    {
        // validate newEmail parameter.
        // if invalid, throw exception

        Email = newEmail;
    }
}

internal interface IPersonRepository
{
    Person GetById(int id);
}