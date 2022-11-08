namespace PG3302Eksamen.Model;

public abstract class Transaction {
    public int Id { get; set; }
    public decimal Amount { get; set; }

    public int FromAccount { get; set; }

    public int ToAccount { get; set; }
}