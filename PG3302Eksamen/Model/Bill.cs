namespace PG3302Eksamen.Model;

public class Bill {
    public int Id { get; set; }
    public DateTime DueDate { get; set; }
    public string AccountNumber { get; set; }

    public decimal Amount { get; set; }
    public string Recipient { get; set; }
    public string MessageField { get; set; }
    public BillStatusEnum Status { get; set; }

    public int OwnerId { get; set; }


    public Bill CreateBill(string accountNumber, string recipient, string messageField,
        decimal amount,
        BillStatusEnum status, DateTime dueDate, int ownerId) {
        return new Bill {
            AccountNumber = accountNumber,
            Recipient = recipient,
            MessageField = messageField,
            Amount = amount,
            Status = status,
            DueDate = dueDate,
            OwnerId = ownerId
        };
    }
}