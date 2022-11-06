using PG3302Eksamen.Interfaces;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Repositories;

public sealed class PersonRepository : IPersonRepository, IDisposable {
    private readonly BankContext _context;
    private bool _disposed;


    public PersonRepository(BankContext context) {
        _context = context;
    }

    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public Person GetById(int id) {
        return _context.Persons.Find(id) ?? throw new InvalidOperationException();
    }

    // TODO usikker på om disse skal være toList() eller ikke, de konverteres ofte til det når vi bruker det
    // todo får se senere!
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


    public void AddNewAccount(Account entity) {
        _context.Accounts.Add(entity);
        _context.SaveChanges();
    }

    public void ChangePassword(int id, string newPassword) {
        var personToUpdate = GetById(id);
        personToUpdate.Password = newPassword;
        _context.SaveChanges();
    }

    public Person GetBySocialSecNumber(string ssn) {
        return _context.Persons.FirstOrDefault(person => person.SocialSecurityNumber == ssn);
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