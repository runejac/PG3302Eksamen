using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Interfaces;

public interface ITransactionRepository : IRepository<Transaction> {
    List<Transaction> GetRecentTransactions();
    void PayBill(Bill bill);
    void Transfer(Account accountFrom, Account accountTo);
}