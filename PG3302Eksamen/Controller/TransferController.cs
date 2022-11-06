using PG3302Eksamen.Interfaces;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen.Controller;

public class TransferController : ITransaction {
	private readonly AccountRepository _accountRepository = new(new BankContext());
	private readonly TransactionRepository _transactionRepository = new(new BankContext());
	private  Transfer _transfer = new();
	private Transaction _transaction;



	public void Pay() {
		throw new NotImplementedException();
	}

	public void Execute() {
		throw new NotImplementedException();
	}
	

	public void Execute(decimal amount, Account fromAccount, Account toAccount) {
		var transaction = _transfer.CreateTransfer(amount, fromAccount, toAccount);
		_transactionRepository.ProcessTransaction(transaction);

		fromAccount.Balance -= amount;
		toAccount.Balance += amount;
		_accountRepository.Update(fromAccount);
		_accountRepository.Update(toAccount);
	}
	


	public Transaction getModel<T>() {
		return _transfer;
	}
}