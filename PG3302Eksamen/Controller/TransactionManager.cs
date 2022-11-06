using PG3302Eksamen.Interfaces;

namespace PG3302Eksamen.Controller;

public class TransactionManager {
	private ITransaction _transaction;


	public TransactionManager CreateTransactionManager(ITransaction transaction) {
		return new TransactionManager {
			_transaction = transaction
		};
	}
}