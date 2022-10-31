using A_Team.Core.Interfaces;
using A_Team.Core.Model;

namespace A_Team.Core.Repositories;

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

    public void UpdateAddress(int id, string newAddress) {
        var personToUpdate = GetById(id);
        personToUpdate.Address = newAddress;
        _context.SaveChanges();
    }
    
    //TODO: Implement this function
    public void AddNewAccount() {
        throw new NotImplementedException();
    }

    public void ChangePassword(int id, string newPassword) {
        var personToUpdate = GetById(id);
        personToUpdate.Password = newPassword;
        _context.SaveChanges();
    }
    
    private void Dispose(bool disposing) {
        if (!_disposed)
            if (disposing)
                _context.Dispose();
        _disposed = true;
    }
}