using A_Team.Core.Model;
using A_Team.Core.Model.AccountModel;
using A_Team.Core.Repositories;

namespace PG3302Eksamen;

public static class Program {
	public static void Main(string[] args) {
		var accountRepository = new AccountRepository();
		var billRepository = new BillRepository();
		var personRepository = new PersonRepository();
		var transactionRepository = new TransactionRepository();

		var savingAccount = new SavingsAccountFactory().InitializeAccount(12, 5, 10,
			"Fattig",
			new Person("Fra ekte repo, runes home", "Rune", "Oliveira", "uno dos",
				"94474621",
				"0505040234", new DateTime().Date),
			"111111111", DateTime.Now);
		var currentAccount = new CurrentAccountFactory().InitializeAccount(0, 1, 20,
			"Brukskonto 2",
			new Person("Fra ekte repo, Joachims home", "Rune", "Oliveira", "uno dos tres",
				"92262913",
				"500", new DateTime().Date),
			"2", DateTime.Now);

		var bill = new Bill().CreateBill(currentAccount, savingAccount, "With love", 123,
			BillStatusEnum.PAID,
			DateTime.Now);

		//billRepository.Insert(bill);

		//accountRepository.Insert(savingAccount);
		//accountRepository.Insert(currentAccount);
		foreach (var account in accountRepository.GetSortedByOwner(5))
			Console.WriteLine(account.Name);
	}
}