using PG3302Eksamen.Interfaces;
using PG3302Eksamen.Model;

namespace PG3302Eksamen.Controller;

public class TransferController : ITransaction {
    private readonly Transfer _transfer;

    public TransferController(Transfer transfer) {
        _transfer = transfer;
    }


    public void Pay() {
        throw new NotImplementedException();
    }

    public Transaction getModel<T>() {
        return _transfer;
    }
}