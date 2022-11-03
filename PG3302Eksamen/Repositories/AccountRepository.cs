using PG3302Eksamen.Interfaces;
using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Repositories;

public sealed class AccountRepository : IAccountRepository, IDisposable {
    private readonly BankContext _context = new();
    private bool _disposed;
    public AccountRepository() {}
    public AccountRepository(BankContext context) {
        _context = context;
    }
    public Account GetById(int id) {
        return _context.Accounts.Find(id) ?? throw new InvalidOperationException();
    }

    public IEnumerable<Account> GetAll() {
        return _context.Accounts.AsQueryable() ?? throw new InvalidOperationException();
    }

    public void Insert(Account entity) {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public void Remove(Account entity) {
        _context.Remove(entity);
        _context.SaveChanges();
    }

    public List<string> GetAllAccountNumbers() {
        var response = GetAll();
        return response.Select(accounts => accounts.AccountNumber).ToList();
    }

    public IOrderedEnumerable<Account> GetSortedByBalance() {
        return GetAll().OrderByDescending(acc => acc.Balance);
    }

    public IEnumerable<Account> GetSortedByName(string name) {
        return GetAll().Where(acc => acc.Name.Equals(name));
    }

    public IEnumerable<Account> GetSortedByOwner(int id) {
        return _context.Accounts.Where(e => e.OwnerId == id);
    }

    public void ChangeAccountName(int id, string newName) {
        var accountToUpdate = GetById(id);
        accountToUpdate.Name = newName;
        _context.SaveChanges();
    }

    public void UpdateBalance(int id, decimal newBalance) {
        var accountToUpdate = GetById(id);
        accountToUpdate.Balance = newBalance;
        _context.SaveChanges();
    }

    public void Save() {
        _context.SaveChanges();
    }

    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing) {
        if (!_disposed)
            if (disposing)
                _context.Dispose();
        _disposed = true;
    }
}