using PG3302Eksamen.Interfaces;
using PG3302Eksamen.Model;

namespace PG3302Eksamen.Repositories;

public sealed class PersonRepository : IPersonRepository, IDisposable {
    private readonly BankContext _context = new();
    private bool _disposed;

    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public Person GetById(int id) {
        return _context.Persons.Find(id) ?? throw new InvalidOperationException();
    }

    public IEnumerable<Person> GetAll() {
        return _context.Persons.AsQueryable() ?? throw new InvalidOperationException();
    }

    public void Insert(Person entity) {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public void Remove(Person entity) {
        _context.Remove(entity);
        _context.SaveChanges();
    }

    public void UpdateAddress(string address) {
        throw new NotImplementedException();
    }

    public void AddNewAccount() {
        throw new NotImplementedException();
    }

    public void ChangePassword(string password) {
        throw new NotImplementedException();
    }


    private void Dispose(bool disposing) {
        if (!_disposed)
            if (disposing)
                _context.Dispose();
        _disposed = true;
    }
}