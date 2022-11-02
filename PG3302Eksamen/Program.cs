using PG3302Eksamen.Controller;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen;

public static class Program {
    public static void Main(string[] args) {
        var accountRepository = new AccountRepository();
        var billRepository = new BillRepository();
        var personRepository = new PersonRepository();
        var transactionRepository = new TransactionRepository();
        DepositController depositController = new();
        AccountController accountController = new();


        var c = new SavingsAccountFactory().InitializeAccount(0, 1, 100,
            "Brukskonto",
            new Person("DOOP", "Daniel", "Lysak", "uno dos tres",
                "92262913",
                "06049524733", new DateTime().Date),
            "222222222", DateTime.Now);

        var c2 = new SavingsAccountFactory().InitializeAccount(0, 1, 100,
            "Spare",
            new Person("WOOP", "Daniel", "Lysak", "uno dos tres",
                "92262913",
                "06049524733", new DateTime().Date),
            "11111111", DateTime.Now);


        accountController.CreateAccount(0, 1, 100,
            "Spare",
            new Person("WOOP", "Daniel", "Lysak", "uno dos tres",
                "92262913",
                "06049524733", new DateTime().Date),
            "11111111", DateTime.Now);

        depositController.CreateDeposit(c, c2, 100);
        depositController.Pay();


        // Command has been added to the queue, but not executed.

        // This executes the commands.


        Console.WriteLine(c.Balance);
        Console.WriteLine(c2.Balance);
    }
}