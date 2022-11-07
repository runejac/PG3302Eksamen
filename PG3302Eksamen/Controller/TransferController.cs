using PG3302Eksamen.Interfaces;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen.Controller;

public class TransferController : ITransaction {
	private readonly AccountRepository _accountRepository = new(new BankContext());
	private readonly BillRepository _billRepository = new(new BankContext());

	private readonly TransactionRepository
		_transactionRepository = new(new BankContext());

	private readonly Transfer _transfer = new();

	private Transaction _transaction;


	public void Pay() {
		throw new NotImplementedException();
	}

	public void Execute() {
		throw new NotImplementedException();
	}

	public Transaction getModel<T>() {
		return _transfer;
	}


	public void Execute(decimal amount, Account fromAccount, Account toAccount) {
		var transaction = _transfer.CreateTransfer(amount, fromAccount, toAccount);

		//_transactionRepository.ProcessTransaction(transaction);

		fromAccount.Balance -= amount;
		toAccount.Balance += amount;
		_accountRepository.Update(fromAccount);
		_accountRepository.Update(toAccount);
	}


	public void ExecuteBillPayment(Account selectedFromAccount, Bill selectedBill) {
		var transaction = _transfer.CreateBillPayment(selectedBill.Amount,
			selectedFromAccount, selectedBill);


		// TODO does pay a bill, but can not make transaction of it yet
		//_transactionRepository.ProcessTransaction(transaction);


		selectedFromAccount.Balance -= selectedBill.Amount;
		selectedBill.Status = BillStatusEnum.Paid;

		_billRepository.Update(selectedBill);
		_accountRepository.Update(selectedFromAccount);
	}
}