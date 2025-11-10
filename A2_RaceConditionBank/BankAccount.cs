using System;
using System.Threading;

namespace A2_RaceConditionBank;
public class BankAccount
{
    private int balance;
   
    
    public BankAccount(int initial) 
    { 
        balance = initial; 
    }
    
    public void Deposit(int amount) 
    {
        balance += amount;
    }
    
    public void Withdraw(int amount) 
    {
        balance -= amount;
    }
    
    public int GetBalance() 
    {
        return balance;
    }
}
