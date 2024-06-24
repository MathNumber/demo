namespace Bai2
{
    public delegate void BalanceChanged(decimal newBalance);

    class Bank
    {
        public event BalanceChanged OnBalanceChanged;

        public void UpdateAccount(decimal price)
        {
            Console.WriteLine("New account balance: {0}", price);
            OnBalanceChanged?.Invoke(price);
        }

        static void Main(string[] args)
        {
            Bank bank = new Bank();

            bank.UpdateAccount(1000);
            bank.UpdateAccount(2000);

            Console.ReadLine();
        }
    }
}
