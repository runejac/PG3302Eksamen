using A_Team.Core.Model;
using A_Team.Core.Model.AccountModel;

namespace A_Team.Core.Interfaces;

public interface ITransactionRepository : IRepository<Transaction> {
    IQueryable<Transaction> GetRecentTransactions(int days);
    void PayBill(Bill bill);
    void Transfer(int accountFromId, int accountToId, decimal amount);
}