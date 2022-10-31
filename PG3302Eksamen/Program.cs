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

        var savingAccount = new SavingsAccountFactory().InitializeAccount(12, 5, 10,
            "Fattig",
            new Person("Fra ekte repo, runes home", "Rune", "Oliveira", "uno dos",
                "94474621",
                "0505040234", new DateTime().Date),
            "111111111", DateTime.Now);
        var currentAccount = new CurrentAccountFactory().InitializeAccount(0, 1, 20,
            "Brukskonto",
            new Person("Fra ekte repo, runes home", "Daniel", "Lysak", "uno dos tres",
                "92262913",
                "06049524733", new DateTime().Date),
            "222222222", DateTime.Now);

        var bill = new Bill().CreateBill(currentAccount, savingAccount, "With love", 123,
            BillStatusEnum.PAID,
            DateTime.Now);

        //billRepository.Insert(bill);

        accountRepository.Insert(savingAccount);
        accountRepository.Insert(currentAccount);


        foreach (var account in accountRepository.GetSortedByBalance())
            Console.WriteLine(account.Balance);
    }
}