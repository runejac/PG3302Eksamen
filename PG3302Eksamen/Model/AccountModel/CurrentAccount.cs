using System.ComponentModel.DataAnnotations.Schema;

namespace A_Team.Core.Model.AccountModel;

public class CurrentAccount : Account {
    [Column("Interest")] public override int Interest { get; set; }

    [Column("WithdrawLimit")] public override int WithdrawLimit { get; set; }
}