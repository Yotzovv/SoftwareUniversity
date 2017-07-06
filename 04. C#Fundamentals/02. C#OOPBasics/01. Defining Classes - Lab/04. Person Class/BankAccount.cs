internal class BankAccount
{
    int id;
    double balance;

    public int Id
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    }
    public double Balance
    {
        get
        {
            return this.balance;
        }
        set
        {
            this.balance = value;
        }
    }


    public void Deposit(double amount)
    {
        this.balance += amount;
    }

    public void Withdraw(double amount)
    {
        this.balance -= amount;
    }

    public override string ToString()
    {
        return $"Account ID{this.Id}, balance {this.Balance:f2}";
    }
}