namespace School_API.Data
{
    public class BankAccount
    {
        public decimal Balance { get; set; }

        public BankAccount()
        {
            Balance = 100;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Wrong input");

            Balance+=amount;
           
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Wrong input");
            if (amount > Balance)
                throw new ArgumentException("Insufficinet funds");

            Balance -= amount;
        }

    }
}
