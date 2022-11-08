using PG3302Eksamen.Interfaces;
using PG3302Eksamen.Model;

namespace PG3302Eksamen.Repositories;

public sealed class TransactionRepository : ITransactionRepository, IDisposable {
    private readonly BankContext _context;
    private bool _disposed;

    public TransactionRepository(BankContext context) {
        _context = context;
    }

    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public Transaction GetById(int id) {
        return _context.Transactions.Find(id) ?? throw new InvalidOperationException();
    }

    public IEnumerable<Transaction> GetAll() {
        return _context.Transactions.AsQueryable() ??
               throw new InvalidOperationException();
    }

    public void Insert(Transaction entity) {
        throw new NotImplementedException();
    }

    public void Remove(Transaction entity) {
        _context.Remove(entity);
        _context.SaveChanges();
    }

    // public List<Transaction> GetRecentTransactions(int days) {
    //   var now = DateTime.Now;
    //  return new List<Transaction>(_context.Transactions.Where(
    //    e => e.Date > now - TimeSpan.FromDays(days)
    //  ));
    // }

    public List<Transaction> GetRecentTransactions(int days) {
        throw new NotImplementedException();
    }

    public void PayBill(int billId, string fromAccountNr) {
        var billRepo = new BillRepository(_context);
        var idOfBill = billRepo.GetById(billId);
        billRepo.UpdateBillStatus(idOfBill.Id, BillStatusEnum.Paid);
        // Insert(new Transaction().CreateTransaction(idOfBill.Id, DateTime.Now, fromAccountNr, idOfBill.AccountNumber));
    }

    public void ProcessTransaction() {
        throw new NotImplementedException();
    }

    public void ProcessTransaction(Transaction entity) {
        _context.Add(entity);
        _context.SaveChanges();
    }


    private void Dispose(bool disposing) {
        if (!_disposed) {
            if (disposing) {
                _context.Dispose();
            }
        }

        _disposed = true;
    }
}