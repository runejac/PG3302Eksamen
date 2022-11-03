using PG3302Eksamen.Model;
using PG3302Eksamen.Repositories;
using static BCrypt.Net.BCrypt;

namespace PG3302Eksamen.Controller;

public class PersonController {
	private readonly PersonRepository
		_personRepository =
			new(); // FIXME til STIAN: jeg fjerna new(new BankContext()) her, hvis test ikke fungerer er det nok derfor

	private Person _person = new();


	// TODO: Probably move creation to its own class, the same with prompt as its not persons job


	public Person? Authenticate(string ssn, string password) {
		_person = _personRepository.GetBySocialSecNumber(ssn);


		if (ssn == _person.SocialSecurityNumber) {
			return Verify(password, _person.Password) ? _person : null;
		}

		return null;
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