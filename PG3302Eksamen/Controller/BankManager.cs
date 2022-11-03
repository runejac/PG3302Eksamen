using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Controller;

public class BankManager : IBankManager {
    private static BankManager _instance;
    //private static PersonRepository _personRepository;


    /*public BankManager(IUserReader userReader) {
        UserReader = userReader;
    }*/

    //private IUserReader UserReader { get; }

    /*private static PersonRepository PersonRepository {
        get => _personRepository;
        set => _personRepository =
            value ?? throw new ArgumentNullException(nameof(value));
    }*/

    public void Run() {
        //Ui.WelcomeMessage();
    }


    /*----------------------------------------------------**/


    public void TransferMoney(Person person, Account fromAccount, Account toAccount,
        decimal amount) {
    }

}