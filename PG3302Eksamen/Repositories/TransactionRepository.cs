using PG3302Eksamen.Interfaces;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Repositories;

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
        throw new NotImplementedException();
    }

    public void Insert(Transaction entity) {
        try {
            _context.Add(entity);
            _context.SaveChanges();
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Transaction> GetRecentTransactions() {
        throw new NotImplementedException();
    }

    public void PayBill(Bill bill) {
        throw new NotImplementedException();
    }

    public void Transfer(Account accountFrom, Account accountTo) {
        throw new NotImplementedException();
    }


    private void Dispose(bool disposing) {
        if (!_disposed)
            if (disposing)
                _context.Dispose();
        _disposed = true;
    }
}