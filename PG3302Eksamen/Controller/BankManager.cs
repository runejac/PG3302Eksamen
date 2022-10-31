using A_Team.Core.Model;
using A_Team.Core.Model.AccountModel;
using A_Team.Core.Repositories;

namespace A_Team.Core.Controller;

public class BankManager : IBankManager {
	private static BankManager _instance;

	private BankManager() {
	}

	public void Run() {
		getInstance();
	}

	public static BankManager getInstance() {
		if (_instance == null) _instance = new BankManager();
		return _instance;
	}

	public string SavingsOrCurrentAcc() {
		string choice;
		Console.WriteLine("Do you want it to be a savings account or a current account?");
		Console.WriteLine("1. savings account");
		Console.WriteLine("2. current account");

		choice = Console.ReadLine();

		return choice;
	}


	public void CreateBankAccount(int personIdentifier) {
		var personRep = new PersonRepository();
		var accRep = new AccountRepository();
		var random = new Random();
		var numbers = random.NextInt64(00000000000, 99999999999);
		var accountNumberGenerated = numbers.ToString();
		var savingsOrCurrentAcc = SavingsOrCurrentAcc();

		foreach (var accNr in accRep.GetAllAccountNumbers())
			if (accountNumberGenerated == accNr) {
				numbers = random.NextInt64(00000000000, 99999999999);
				accountNumberGenerated = numbers.ToString();
			}

		if (savingsOrCurrentAcc == "1") {
			Console.WriteLine("You've chosen a savings account");
			Console.WriteLine("What do you want to name the savings account?");
			var accName = Console.ReadLine();
			var newAcc = new SavingsAccountFactory().InitializeAccount(
				accName, personRep.GetById(personIdentifier).Id, accountNumberGenerated);
			personRep.AddNewAccount(newAcc);
		}
		else if (savingsOrCurrentAcc == "2") {
			Console.WriteLine("You've chosen a current account");
			Console.WriteLine("What do you want to name the current account?");
			var accName = Console.ReadLine();
			var newAcc = new CurrentAccountFactory().InitializeAccount(accName,
				personRep.GetById(personIdentifier).Id, accountNumberGenerated
			);
			personRep.AddNewAccount(newAcc);
		}
	}


	public void TransferMoney(Person person, Account fromAccount, Account toAccount,
		decimal amount) {
	}
}