using PG3302Eksamen.Interfaces;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Controller;

public class DepositController : ITransaction {
    private Deposit Deposit = new();


    public void Pay() {
        throw new NotImplementedException();
    }

    public Transaction getModel<T>() {
        return Deposit;
    }


    public void CreateDeposit(Account fromAccount, Account toAccount, decimal amount) {
        Deposit = Deposit.CreateDeposit(fromAccount, toAccount, amount);
    }
}