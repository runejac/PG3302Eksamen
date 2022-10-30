using A_Team.Core.Model;
using A_Team.Core.Model.AccountModel;

namespace A_Team.Core.Interfaces;

public interface ITransactionRepository : IRepository<Transaction> {
    List<Transaction> GetRecentTransactions();
    void PayBill(Bill bill);
    void Transfer(Account accountFrom, Account accountTo);
}