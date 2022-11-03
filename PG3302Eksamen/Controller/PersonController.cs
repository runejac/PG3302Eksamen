using PG3302Eksamen.Model;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen.Controller;

public class PersonController {
    private readonly PersonRepository personRepository = new(new BankContext());
    private Person Person = new();


    // TODO: Probably move creation to its own class, the same with prompt as its not persons job

    public void CreatePerson(string address, string firstName, string lastName, string password,
        string phoneNumber,
        string socialSecurityNumber, string email) {
        Person = Person.CreatePerson(address, firstName, lastName, password, phoneNumber, socialSecurityNumber, email);
    }

    public bool ValidateSocialSecurity() {
        var match = personRepository.GetAll()
            .ToList()
            .FirstOrDefault(person =>
                person.SocialSecurityNumber.Equals(Person.SocialSecurityNumber));


        if (match is not null && personRepository.GetAll().ToList().Count >= 1) return true;
        personRepository.Insert(Person);
        return false;
    }
}