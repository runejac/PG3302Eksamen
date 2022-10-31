using A_Team.Core.Model;
using A_Team.Core.Model.AccountModel;

namespace A_Team.Core.Interfaces;

public interface IPersonRepository : IRepository<Person> {
	void UpdateAddress(int id, string newAddress);
	void AddNewAccount(Account entity);
	void ChangePassword(int id, string newPassword);
}