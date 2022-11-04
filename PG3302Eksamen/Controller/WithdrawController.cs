using PG3302Eksamen.Interfaces;
using PG3302Eksamen.Model;

namespace PG3302Eksamen.Controller;

public class WithdrawController : ITransaction {
    
    public WithdrawController(Withdraw withdraw) {
        Withdraw = withdraw;
    }

    public Withdraw Withdraw { get; set; }


    public void Pay() {
        throw new NotImplementedException();
    }

    public Transaction getModel<T>() {
        return Withdraw;
    }
}