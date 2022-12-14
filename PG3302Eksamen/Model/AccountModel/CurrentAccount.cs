using System.ComponentModel.DataAnnotations.Schema;

namespace PG3302Eksamen.Model.AccountModel;

public class CurrentAccount : Account {
    [Column("Interest")] public override int Interest { get; set; } = 2;
    [Column("WithdrawLimit")] public override int WithdrawLimit { get; set; } = 0;
}