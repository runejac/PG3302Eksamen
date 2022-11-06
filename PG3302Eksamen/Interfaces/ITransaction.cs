using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Interfaces;

public interface ITransaction {
	void Pay();
	void Execute(decimal amount, Account fromAccount, Account toAccount);

	Transaction getModel<T>();
}