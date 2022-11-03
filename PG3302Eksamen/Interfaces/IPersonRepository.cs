using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Interfaces;

public interface IPersonRepository : IRepository<Person> {
    void UpdateAddress(int id, string newAddress);
    void AddNewAccount(Account entity);
    void ChangePassword(int id, string newPassword);
}