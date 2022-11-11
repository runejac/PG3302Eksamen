using PG3302Eksamen.Model;

namespace PG3302Eksamen.Interfaces;

public interface ITransaction {
    void Pay();
    void Execute();

    Transaction getModel<T>();
}