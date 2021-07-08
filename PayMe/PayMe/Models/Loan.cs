namespace PayMe.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Loan
    {
        public int Amount { get; set; }
        public string AmountDisplay { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }

        /// <summary>
        /// If loan amount is bigger then zero, the color will be red. Default is green.
        /// The amount will show in its absolute state.
        /// </summary>
        /// <param name="amount"></param>
        public Loan(int amount)
        {
            Amount = amount;
            if (amount > 0)
            {
                Color = "Green";
                AmountDisplay = $"+{Amount} ";
            }
            else
            {
                Color = "Red";
                AmountDisplay = $"{Amount} ";
            }
        }
    }
}
