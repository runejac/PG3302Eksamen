using A_Team.Core.Model;
using A_Team.Core.Model.AccountModel;

namespace A_Team.Core.Interfaces;

public interface ITransactionRepository : IRepository<Transaction> {
    List<Transaction> GetRecentTransactions(int days);
    void PayBill(int billId, string fromAccountNr);
    void Transfer(int accountFromId, int accountToId, decimal amount);
}