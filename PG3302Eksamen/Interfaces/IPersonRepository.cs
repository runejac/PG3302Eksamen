using PG3302Eksamen.Model;

namespace PG3302Eksamen.Interfaces;

public interface IPersonRepository : IRepository<Person> {
    void UpdateAddress(string address);
    void AddNewAccount();
    void ChangePassword(string password);
}