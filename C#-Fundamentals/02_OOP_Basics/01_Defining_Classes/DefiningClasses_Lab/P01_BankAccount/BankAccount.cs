﻿
public class BankAccount
{
    private int id;
    private decimal balance;

    public int Id { get; set; }
    public decimal Balance { get; set; }

    public void Deposit(decimal amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        Balance -= amount;
    }

    public override string ToString()
    {
        return $"Account {this.Id}, balance {this.balance}";
    }
}

