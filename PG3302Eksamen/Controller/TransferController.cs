using PG3302Eksamen.Interfaces;
using PG3302Eksamen.Model;

namespace PG3302Eksamen.Controller;

public class TransferController : ITransaction {
    public Transfer Transfer;

    public TransferController(Transfer transfer) {
        Transfer = transfer;
    }


    public void Pay() {
        throw new NotImplementedException();
    }

    public Transaction getModel<T>() {
        return Transfer;
    }
}