namespace fastfood
{
    internal class Money
    {
        private double amount;
        private readonly string currency;

        public Money(double amount, string currency)
        {
            this.amount = amount;
            this.currency = currency;
        }

        public override string ToString()
        {
            return amount + " " + currency;
        }

        public void Add(Money price)
        {
            // assert this.currency == price.currency
            amount += price.amount;
        }
    }
}