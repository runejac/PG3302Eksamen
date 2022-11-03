using PG3302Eksamen.Model;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen.Controller;

public class PersonController {
	private readonly PersonRepository _personRepository = new();
	private Person _person = new();


	// TODO: Probably move creation to its own class, the same with prompt as its not persons job


	public bool Authenticate(string ssn, string password) {
		Console.WriteLine("Authenticating...");
		Console.WriteLine(ssn + password);

		var ssnChecker = _personRepository.GetAll().ToList()
			.FirstOrDefault(person => person.SocialSecurityNumber.Equals(ssn));

		ValidateSocialSecurityNumber();


		Console.WriteLine("hello"+ ssnChecker);

		return ssnChecker != null && ssnChecker.Password.Equals(password);
	}


	public void CreatePerson(string address, string firstName, string lastName,
		string password,
		string phoneNumber,
		string socialSecurityNumber, string email) {
		_person = _person.CreatePerson(address, firstName, lastName, password,
			phoneNumber,
			socialSecurityNumber, email);
	}

	public bool ValidateSocialSecurityNumber() {
		var match = _personRepository.GetAll()
			.ToList()
			.FirstOrDefault(person =>
				person.SocialSecurityNumber.Equals(_person.SocialSecurityNumber));


		if (match is not null && _personRepository.GetAll().ToList().Count >= 1) {
			return true;
		}

		_personRepository.Insert(_person);
		return false;
	}

	public Person getPerson() {
		return _person;
	}
}