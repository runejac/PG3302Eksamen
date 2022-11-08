using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Interfaces;

public interface IAccountRepository : IRepository<Account> {
    IOrderedEnumerable<Account> GetSortedByBalance();
    IEnumerable<Account> GetSortedByName(string name);
    IEnumerable<Account> GetSortedByOwner(int id);
    public List<string> GetAllAccountNumbers();
    void ChangeAccountName(int id, string newName);
    public void Update(Account entity);
    void Save();
}