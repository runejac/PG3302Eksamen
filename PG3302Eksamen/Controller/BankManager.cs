using A_Team.Core.Model;
using A_Team.Core.Model.AccountModel;
using A_Team.Core.Repositories;
using PG3302Eksamen.View;

namespace A_Team.Core.Controller;

public class BankManager : IBankManager {
	private static BankManager _instance;

	private BankManager() {
	}

	public void Run() {
		//getInstance();
	}


	private static string SavingsOrCurrentAcc() {
		Ui.AskUserWhatTypeOfAccountToBeMade();

		var choice = Console.ReadLine();

		if (choice is "1" or "2") return choice;
		Ui.InvalidInputMessage();
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
				Ui.InvalidInputMessage();
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
				Ui.InvalidInputMessage();
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