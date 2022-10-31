using A_Team.Core.Model.AccountModel;

namespace A_Team.Core.Interfaces;

public interface IAccountRepository : IRepository<Account> {
    IOrderedEnumerable<Account> GetSortedByBalance();
    IEnumerable<Account> GetSortedByName(string name);
    IEnumerable<Account> GetSortedByOwner(int id);
    void UpdateAccount(Account account);
    void Save();
}