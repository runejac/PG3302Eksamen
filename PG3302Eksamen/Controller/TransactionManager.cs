/*using PG3302Eksamen.Interfaces;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen.Controller;

public class TransactionManager {
	private Transaction _transaction;
	private readonly TransactionRepository _transactionRepository = new(new BankContext());
	

	public TransactionManager(Transaction transaction) {
		_transaction = transaction;
	}

	public TransactionManager ProcessTransaction(Transaction transaction) {
		_transactionRepository.ProcessTransaction(transaction);
		return new TransactionManager(transaction);
	}
	
}



public class lol : ITransaction {
	private readonly AccountRepository _accountRepository = new(new BankContext());
	private readonly TransactionRepository _transactionRepository = new(new BankContext());
	private readonly Transfer _transfer = null!;
	private Transaction _transaction = null!;
	private readonly Account _fromAccount;
	private readonly Account _toAccount;
	readonly decimal _amount;



	public void Pay() {
		throw new NotImplementedException();
	}

	public void Execute() {
		throw new NotImplementedException();
	}


	
	public lol ProcessTransaction() {
		_transactionRepository.ProcessTransaction(_transaction);
		_accountRepository.Update(_fromAccount);
		_accountRepository.Update(_toAccount);
		return this;
	}

	public lol Calculate() {
		_fromAccount.Balance -= _amount;
		_toAccount.Balance += _amount;
		return this;
	}

	public lol NewTransaction() {
		_transaction = _transfer.CreateTransfer(_amount, _fromAccount, _toAccount);
		return this;
	}



	public Transaction getModel<T>() {
		return _transfer;
	}
}*/