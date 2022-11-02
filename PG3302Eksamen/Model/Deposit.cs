﻿using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Model;

public class Deposit : Transaction {
    public new decimal Amount { get; set; }

    public new int Id { get; set; }


    public Deposit CreateDeposit(Account toAccount, Account fromAccount, decimal amount) {
        return new Deposit {
            ToAccount = toAccount,
            FromAccount = fromAccount,
            Amount = amount
        };
    }
}