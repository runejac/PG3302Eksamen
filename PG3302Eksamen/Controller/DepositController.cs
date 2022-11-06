using PG3302Eksamen.Interfaces;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Controller;

public class DepositController : ITransaction {
	private Deposit _deposit = new();


	public void Pay() {
		throw new NotImplementedException();
	}

	public void Execute(decimal amount, Account fromAccount, Account toAccount) {
		throw new NotImplementedException();
	}

	public Transaction getModel<T>() {
		return _deposit;
	}

	public void Execute() {
		throw new NotImplementedException();
	}


	public void CreateDeposit(Account fromAccount, Account toAccount, decimal amount) {
		_deposit = _deposit.CreateDeposit(fromAccount, toAccount, amount);
	}
}