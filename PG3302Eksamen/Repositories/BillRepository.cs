using A_Team.Core.Interfaces;
using A_Team.Core.Model;

namespace A_Team.Core.Repositories;

public sealed class BillRepository : IBillRepository, IDisposable {
    private readonly BankContext _context = new();
    private bool _disposed;
    
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

    //TODO: Test this function
    public IOrderedEnumerable<Bill> GetSortedByDueDateDescending() {
        return GetAll().OrderByDescending(bill => bill.DueDate);
    }

    //TODO: Test this function
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

    private void Dispose(bool disposing) {
        if (!_disposed)
            if (disposing)
                _context.Dispose();
        _disposed = true;
    }
}