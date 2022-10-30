using A_Team.Core.Model;

namespace A_Team.Core.Interfaces;

public interface IPersonRepository : IRepository<Person> {
    void UpdateAddress(string address);
    void AddNewAccount();
    void ChangePassword(string password);
}