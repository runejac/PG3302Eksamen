using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Interfaces;

public interface ITransactionRepository : IRepository<Transaction> {
    List<Transaction> GetRecentTransactions(int days);
    void PayBill(int billId, string fromAccountNr);
    void Transfer(int accountFromId, int accountToId, decimal amount);
}