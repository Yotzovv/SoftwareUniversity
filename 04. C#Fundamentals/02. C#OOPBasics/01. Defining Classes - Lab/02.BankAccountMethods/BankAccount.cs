public class BankAccount
{
    int id;
    double balance;

    public int Id { get; set; }
    public double Balance { get; set; }


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
        return $"Account {this.id}, balance {this.balance}";
    }
}