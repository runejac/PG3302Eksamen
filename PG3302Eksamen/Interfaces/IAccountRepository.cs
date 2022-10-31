using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Interfaces;

public interface IAccountRepository : IRepository<Account> {
    IOrderedEnumerable<Account> GetSortedByBalance();
    List<Account> GetSortedByName(string name);

    void UpdateAccount(Account account);
    void Save();
}