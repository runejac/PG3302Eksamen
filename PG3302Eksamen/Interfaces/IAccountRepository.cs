using A_Team.Core.Model.AccountModel;

namespace A_Team.Core.Interfaces;

public interface IAccountRepository : IRepository<Account> {
    IOrderedEnumerable<Account> GetSortedByBalance();
    List<Account> GetSortedByName(string name);

    void UpdateAccount(Account account);
    void Save();
}