using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;
using PG3302Eksamen.View;

namespace PG3302Eksamen;

internal static class Program {
    private static void Main(string[] args) {
        
        
        // admin user gets created at the start because bill needs an account, and an account need a person
        
        var personRepository = new PersonRepository(new BankContext());
        var accountRepository = new AccountRepository(new BankContext());
        var exist = personRepository.CheckIfExists(1);
        if (!exist) {
            var person = new Person().CreatePerson("This is", "Admin", "Placeholder",
                "Person", "0", "0", "@");
            personRepository.Insert(person);


            var savingAccount = new CurrentAccountFactory().InitializeAccount("Bill account", person.Id,
                "111111111");

            accountRepository.Insert(savingAccount);
        }

        var ui = new Ui();
        ui.WelcomeMessage();
    }
}