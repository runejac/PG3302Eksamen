using A_Team.Core.Interfaces;
using A_Team.Core.Model;
using A_Team.Core.Model.AccountModel;

namespace A_Team.Core.Repositories;

public sealed class TransactionRepository : ITransactionRepository, IDisposable {
    private readonly BankContext _context = new();
    private bool _disposed;

    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public Transaction GetById(int id) {
        return _context.Transactions.Find(id) ?? throw new InvalidOperationException();
    }

    public IEnumerable<Transaction> GetAll() {
        return _context.Transactions.AsQueryable() ?? throw new InvalidOperationException();
    }

    public void Remove(Transaction entity) {
        _context.Remove(entity);
        _context.SaveChanges();
    }

    public void Insert(Transaction entity) {
            _context.Add(entity);
            _context.SaveChanges();
    }

    public IQueryable<Transaction> GetRecentTransactions(int days) {
        return _context.Transactions.Where(e => e.Date > DateTime.Today - TimeSpan.FromDays(days));
    }

    public void PayBill(Bill bill) {
        throw new NotImplementedException();
    }

    public void Transfer(Account accountFrom, Account accountTo, decimal amount) {
        var from = _context.Accounts.Find(accountFrom);
        var to = _context.Accounts.Find(accountTo);
        if (from == null) return;
        from.Balance -= amount;
        if (to != null) to.Balance += amount;
        _context.SaveChanges();
    }


    private void Dispose(bool disposing) {
        if (!_disposed)
            if (disposing)
                _context.Dispose();
        _disposed = true;
    }
}