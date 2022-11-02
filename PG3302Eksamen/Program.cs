using PG3302Eksamen.Controller;
using PG3302Eksamen.Model;

namespace PG3302Eksamen;

internal static class Program {
	private static void Main(string[] args) {
		/*IUserReader userReader = new UserReader();
		new BankManager(userReader).Run();*/


		new BankManager().Run();
		// var personRepository = new PersonRepository();
		// person objektet må kommet fra en state etter logged in
		//BankManager.CreateBankAccount(personRepository.GetById(1).Id);


		/*
		var billRepository = new BillRepository();
		var transactionRepository = new TransactionRepository();
		var accountRepository = new AccountRepository();
		

		var savingAccount = new SavingsAccountFactory().InitializeAccount("konto1",
			personRepository.GetById(1).Id,
			"111111111");
		
		var currentAccount = new CurrentAccountFactory().InitializeAccount("konto2",
			personRepository.GetById(2).Id,"111111111");*/

		

		//accountRepository.Insert(savingAccount);
		//accountRepository.Insert(currentAccount);
		//accountRepository.UpdateBalance(accountRepository.GetById(1).Id, 1000);
		//accountRepository.UpdateBalance(accountRepository.GetById(2).Id, 1000);


		//personRepository.Insert(new Person("fiskeveien 2", "joachim", "christ",
		//"123", "90237461", "1234", DateTime.Today));
		//personRepository.Insert(new Person("fiskeveien 3", "rune", "christ",
		//	"12345", "90231", "124", DateTime.Today));

		//transactionRepository.Transfer(2, 1, 1);
	}
}