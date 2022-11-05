using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;
using PG3302Eksamen.View;

namespace PG3302Eksamen.Controller;

public class AccountController {
	private readonly BankContext _context = new();
	private Account currentAccount;
	private Account savingsAccount;


	public void CreateSavingsAccount(string name, int ownerId,
		string accountNumber) {
		SavingsAccountFactory savingsAccountFactory = new();

		savingsAccount = savingsAccountFactory.InitializeAccount(name, ownerId,
			accountNumber);
	}

	public void CreateCurrentAccount(string name, int ownerId,
		string accountNumber) {
		CurrentAccountFactory currentAccountFactory = new();

		currentAccount = currentAccountFactory.InitializeAccount(name, ownerId,
			accountNumber);
	}


	private string SavingsOrCurrentAcc() {
		Ui.AskUserWhatTypeOfAccountToBeMade();

		var choice = Console.ReadLine();


		if (choice is "1" or "2") {
			return choice;
		}

		Ui.InvalidInputMessage(null);
		return SavingsOrCurrentAcc();
	}


	public void CreateBankAccount(int personIdentifier) {
		var personRep = new PersonRepository(_context);
		var accRep = new AccountRepository(_context);

		AccountTypeChooser(personIdentifier, personRep,
			GenerateBankAccountNumber(accRep));
	}

	public string GenerateBankAccountNumber(AccountRepository accRep) {
		var random = new Random();
		var numbers = random.NextInt64(0000000, 9999999);
		var accountNumberGenerated = numbers.ToString();

		// checking for existing account numbers	
		foreach (var _ in accRep.GetAllAccountNumbers()
			         .Where(accNr => accNr.Contains(accountNumberGenerated))) {
			// if it already exists, create a new one
			numbers = random.NextInt64(0000000, 9999999);
			accountNumberGenerated = numbers.ToString();
		}

		// make an account number with 1201 pattern (DnB pattern)
		return "1201" + accountNumberGenerated;
	}

	private void AccountTypeChooser(int personIdentifier, PersonRepository personRep,
		string accountNumberGenerated) {
		while (true) {
			var savingsOrCurrentAcc = SavingsOrCurrentAcc();
			string newAccountName;
			switch (savingsOrCurrentAcc) {
				case "1": {
					Ui.ChosenAccountType(new SavingAccount());
					newAccountName = Console.ReadLine() ??
					                 throw new InvalidOperationException();
					if (string.IsNullOrEmpty(newAccountName)) {
						Ui.InvalidInputMessage(null);
						continue;
					}

					SendAccountToDatabase(new SavingsAccountFactory(), personIdentifier,
						newAccountName, personRep,
						accountNumberGenerated);
					break;
				}
				case "2": {
					Ui.ChosenAccountType(new CurrentAccount());
					newAccountName = Console.ReadLine() ??
					                 throw new InvalidOperationException();
					if (string.IsNullOrEmpty(newAccountName)) {
						Ui.InvalidInputMessage(null);
						continue;
					}

					SendAccountToDatabase(new CurrentAccountFactory(), personIdentifier,
						newAccountName, personRep,
						accountNumberGenerated);
					break;
				}
			}

			break;
		}
	}

	private void SendAccountToDatabase(AccountFactory accountType,
		int personIdentifier, string newAccountName,
		PersonRepository personRep, string accountNumberGenerated) {
		var newAccount = accountType.InitializeAccount(
			newAccountName, personRep.GetById(personIdentifier).Id,
			accountNumberGenerated);
		// insert to DB
		personRep.AddNewAccount(newAccount);
	}
}