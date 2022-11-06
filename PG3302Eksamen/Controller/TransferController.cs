using PG3302Eksamen.Interfaces;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen.Controller;

public class TransferController : ITransaction {
	private readonly AccountRepository _accountRepository = new(new BankContext());
	private readonly TransactionManager _transactionManager;
	private readonly Transfer _transfer;


	public void Pay() {
		throw new NotImplementedException();
	}

	public void Execute(decimal amount, Account fromAccount, Account toAccount) {
		//_transactionManager.CreateTransactionManager();

		fromAccount.Balance -= amount;
		toAccount.Balance += amount;
		_accountRepository.Update(fromAccount);
		_accountRepository.Update(toAccount);

		//_accountRepository.Update();
	}


	public Transaction getModel<T>() {
		return _transfer;
	}
}