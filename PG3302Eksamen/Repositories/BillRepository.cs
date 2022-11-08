using PG3302Eksamen.Interfaces;
using PG3302Eksamen.Model;

namespace PG3302Eksamen.Repositories;

public sealed class BillRepository : IBillRepository, IDisposable {
	private readonly BankContext _context;
	private bool _disposed;

	public BillRepository(BankContext bankContext) {
		_context = bankContext;
	}


	public Bill GetById(int id) {
		return _context.Bills.Find(id) ?? throw new InvalidOperationException();
	}

	public IEnumerable<Bill> GetAll() {
		return _context.Bills.AsQueryable() ?? throw new InvalidOperationException();
	}

	public void Insert(Bill entity) {
		_context.Add(entity);
		_context.SaveChanges();
	}

	public void Remove(Bill entity) {
		_context.Remove(entity);
		_context.SaveChanges();
	}

	public IOrderedEnumerable<Bill> GetSortedByDueDateDescending() {
		return GetAll().OrderByDescending(bill => bill.DueDate);
	}

	public IEnumerable<Bill> GetSortedByStatus(BillStatusEnum status) {
		return GetAll().Where(bill => bill.Status.Equals(status));
	}


	public void UpdateBillStatus(int id, BillStatusEnum newStatus) {
		var billToUpdate = GetById(id);
		billToUpdate.Status = newStatus;
		_context.SaveChanges();
	}

	public void Dispose() {
		Dispose(true);
		GC.SuppressFinalize(this);
	}


    public IEnumerable<Bill> GetSortedByOwner(int id) {
        return _context.Bills.Where(e => e.OwnerId == id);
    }
	public void Update(Bill entity) {
		_context.Update(entity);
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