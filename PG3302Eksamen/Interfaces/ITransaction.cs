using PG3302Eksamen.Model;

namespace PG3302Eksamen.Interfaces;

public interface ITransaction {
    void Pay();

    Transaction getModel<T>();
}