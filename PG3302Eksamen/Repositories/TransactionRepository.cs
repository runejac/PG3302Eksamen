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
		_context.Dispose();
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
		throw new NotImplementedException();
	}

	public List<Transaction> GetRecentTransactions(int days) {
		throw new NotImplementedException();
	}

	public void PayBill(int billId, string fromAccountNr) {
		throw new NotImplementedException();
	}

	public void ProcessTransaction() {
		throw new NotImplementedException();
	}

	public void ProcessTransaction(Transaction entity) {
		_context.Add(entity);
		_context.SaveChanges();
	}
}