using PG3302Eksamen.Model;

namespace PG3302Eksamen.Interfaces;

public interface ITransactionRepository : IRepository<Transaction> {
    List<Transaction> GetRecentTransactions(int days);
    void PayBill(int billId, string fromAccountNr);
    void ProcessTransaction();
}