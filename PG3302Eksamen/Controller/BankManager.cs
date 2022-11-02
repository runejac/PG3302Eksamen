using A_Team.Core.Controller;
using A_Team.Core.Model.AccountModel;
using A_Team.Core.Repositories;
using PG3302Eksamen.Model;
using PG3302Eksamen.Repositories;
using PG3302Eksamen.View;

namespace PG3302Eksamen.Controller;

public class BankManager : IBankManager {
	private static BankManager _instance;
	//private static PersonRepository _personRepository;


	/*public BankManager(IUserReader userReader) {
		UserReader = userReader;
	}*/

	//private IUserReader UserReader { get; }

	/*private static PersonRepository PersonRepository {
		get => _personRepository;
		set => _personRepository =
			value ?? throw new ArgumentNullException(nameof(value));
	}*/

	public void Run() {
		//Ui.WelcomeMessage();


		RegisterNewPerson();
	}

	private static void RegisterNewPerson() {
		var personRepository = new PersonRepository();

		Ui.MessageSameLine("Address: ", ConsoleColor.Blue);
		var address = Console.ReadLine();
		Ui.MessageSameLine("First name: ", ConsoleColor.Blue);
		var firstName = Console.ReadLine();
		Ui.MessageSameLine("Last name: ", ConsoleColor.Blue);
		var lastName = Console.ReadLine();
		Ui.MessageSameLine("Phone number: ", ConsoleColor.Blue);
		var phoneNumber = Console.ReadLine();
		Ui.MessageSameLine("Email: ", ConsoleColor.Blue);
		var email = Console.ReadLine();


		var socialSecNumber = SocialSecurityInput();

		PasswordInput(out var password, out var confirmPassword);
		
		if (password == confirmPassword) {
			var newPerson = new Person(address, firstName, lastName, password,
				phoneNumber,
				socialSecNumber, email);
			SocialSecurityChecker(socialSecNumber, newPerson);
		}
		else {
			Ui.InvalidInputMessage("Passwords does not match, try again.");
			PasswordInput(out password, out confirmPassword);
		}
	}

	private static void PasswordInput(out string p, out string cp) {
		Ui.MessageSameLine("Password: ", ConsoleColor.Blue);
		var password = Console.ReadLine();
		Ui.MessageSameLine("Password again: ", ConsoleColor.Blue);
		var confirmPassword = Console.ReadLine();
		{
			p = password;
			cp = confirmPassword;
		}
	}

	private static string? SocialSecurityInput() {
		Ui.MessageSameLine("Social security number: ", ConsoleColor.Blue);
		var socialSecNumber = Console.ReadLine();
		return socialSecNumber;
	}

	private static void SocialSecurityChecker(string socialSecNumber, Person newPerson) {
		var personRepository = new PersonRepository();
		if (personRepository.GetAll().ToList().Count < 1) {
			personRepository.Insert(newPerson);
			Ui.SuccessfullyRegistered(newPerson.FirstName);
		} else {
			foreach (var personsInDb in personRepository.GetAll().ToList()) {
				while (personsInDb.SocialSecurityNumber == socialSecNumber) {
					Ui.InvalidInputMessage(
						"Woops! Social security number already exists!");
					SocialSecurityInput();
				}
				if (personsInDb.SocialSecurityNumber != socialSecNumber) {
					Console.WriteLine("what");
					personRepository.Insert(newPerson);
					Ui.SuccessfullyRegistered(newPerson.FirstName);
				}
			}
		}
	}


	private static string SavingsOrCurrentAcc() {
		Ui.AskUserWhatTypeOfAccountToBeMade();

		var choice = Console.ReadLine();


		if (choice is "1" or "2") return choice;
		Ui.InvalidInputMessage(null);
		return SavingsOrCurrentAcc();
	}


	public static void CreateBankAccount(int personIdentifier) {
		var personRep = new PersonRepository();
		var accRep = new AccountRepository();

		AccountTypeChooser(personIdentifier, personRep,
			GenerateBankAccountNumber(accRep));
	}

	private static string GenerateBankAccountNumber(AccountRepository accRep) {
		var random = new Random();
		var numbers = random.NextInt64(00000000000, 99999999999);
		var accountNumberGenerated = numbers.ToString();

		// checking for existing account numbers
		foreach (var accNr in accRep.GetAllAccountNumbers())
			if (accNr.Contains(accountNumberGenerated)) {
				// if it already exists, create a new one
				numbers = random.NextInt64(00000000000, 99999999999);
				accountNumberGenerated = numbers.ToString();
			}

		return accountNumberGenerated;
	}

	private static void AccountTypeChooser(int personIdentifier,
		PersonRepository personRep, string accountNumberGenerated) {
		var savingsOrCurrentAcc = SavingsOrCurrentAcc();
		string newAccountName;
		if (savingsOrCurrentAcc == "1") {
			Ui.ChosenAccountType(new SavingAccount());
			newAccountName = Console.ReadLine() ?? throw new InvalidOperationException();
			if (string.IsNullOrEmpty(newAccountName)) {
				Ui.InvalidInputMessage(null);
				AccountTypeChooser(personIdentifier, personRep,
					accountNumberGenerated);
			}
			else {
				SendAccountToDatabase(new SavingsAccountFactory(), personIdentifier,
					newAccountName,
					personRep,
					accountNumberGenerated);
			}
		}
		else if (savingsOrCurrentAcc == "2") {
			Ui.ChosenAccountType(new CurrentAccount());
			newAccountName = Console.ReadLine() ?? throw new InvalidOperationException();
			if (string.IsNullOrEmpty(newAccountName)) {
				// TODO Rune: skal legge til flere av disse fra UI- klassen
				Ui.InvalidInputMessage(null);
				AccountTypeChooser(personIdentifier, personRep,
					accountNumberGenerated);
			}
			else {
				SendAccountToDatabase(new CurrentAccountFactory(), personIdentifier,
					newAccountName,
					personRep,
					accountNumberGenerated);
			}
		}
	}

	private static void SendAccountToDatabase(AccountFactory accountType,
		int personIdentifier, string newAccountName,
		PersonRepository personRep, string accountNumberGenerated) {
		var newAccount = accountType.InitializeAccount(
			newAccountName, personRep.GetById(personIdentifier).Id,
			accountNumberGenerated);
		// insert to DB
		personRep.AddNewAccount(newAccount);
	}


	public void TransferMoney(Person person, Account fromAccount, Account toAccount,
		decimal amount) {
	}
}