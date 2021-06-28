namespace PayMe.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Loan
    {
        public int Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; } = "Red";

        public Loan(int amount)
        {
            if (amount > 0)
            {
                Color = "Green";
            }

            Amount = Math.Abs(amount);
        }
    }
}
