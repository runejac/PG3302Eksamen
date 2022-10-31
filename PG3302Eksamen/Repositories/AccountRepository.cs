using A_Team.Core.Interfaces;
using A_Team.Core.Model.AccountModel;

namespace A_Team.Core.Repositories;

public sealed class AccountRepository : IAccountRepository, IDisposable {
    private readonly BankContext _context = new();
    private bool _disposed;

    public Account GetById(int id) {
        return _context.Accounts.Find(id) ?? throw new InvalidOperationException();
    }

    public IEnumerable<Account> GetAll() {
        return _context.Accounts.AsQueryable() ?? throw new InvalidOperationException();
    }

    public void Insert(Account entity) {
        Console.WriteLine(entity.GetType());
        _context.Add(entity);
        _context.SaveChanges();
    }

    public void Remove(Account entity) {
        _context.Remove(entity);
        _context.SaveChanges();
    }

    public IOrderedEnumerable<Account> GetSortedByBalance() {
        return GetAll().OrderByDescending(acc => acc.Balance);
    }

    public IEnumerable<Account> GetSortedByName(string name) {
        return GetAll().Where(acc => acc.Name.Equals(name));
    }
    
    public IEnumerable<Account> GetSortedByOwner(int id) {
        return _context.Accounts.Where(e => e.Owner.Id == id);
    }

    public void UpdateAccount(Account account) {
        throw new NotImplementedException();
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