using A_Team.Core.Model;

namespace A_Team.Core.Interfaces;

public interface IPersonRepository : IRepository<Person> {
    void UpdateAddress(int id, string newAddress);
    void AddNewAccount();
    void ChangePassword(int id, string newPassword);
}