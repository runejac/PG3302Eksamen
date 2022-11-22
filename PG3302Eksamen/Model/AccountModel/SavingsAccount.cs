using System.ComponentModel.DataAnnotations.Schema;

namespace PG3302Eksamen.Model.AccountModel;

public class SavingAccount : Account {
    [Column("Interest")] public override int Interest { get; set; } = 15;

    [Column("WithdrawLimit")] public override int WithdrawLimit { get; set; } = 20;
}