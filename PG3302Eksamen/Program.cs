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
			personRepository.GetById(2).Id,
			"111111111", DateTime.Now);
		
		var currentAccount = new CurrentAccountFactory().InitializeAccount(0, 1, 20,
			"Brukskonto 2",
			personRepository.GetById(1).Id,
			"2", DateTime.Now);

		
		//billRepository.Insert(bill);
		//accountRepository.Insert(savingAccount);
		//accountRepository.Insert(currentAccount);
		//personRepository.Insert(new Person("fiskeveien 2", "joachim", "christ",
		//	"123", "90237461", "1234", DateTime.Today));
		//personRepository.Insert(new Person("fiskeveien 3", "rune", "christ",
		//	"12345", "90231", "124", DateTime.Today));

		transactionRepository.Transfer(1, 2, 10);
		Console.WriteLine(accountRepository.GetById(1).Balance);
		Console.WriteLine(accountRepository.GetById(2).Balance);


		//accountRepository.ChangeAccountName(3, "Hestekonto");
		//personRepository.ChangePassword(1, "ein zwei drei");
		//personRepository.UpdateAddress(1, "Hesteveien 2");
	}
}