using PayMe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace PayMe.Services
{
    public static class DataService
    {
        public static string FilePath { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "loans.txt");

        /// <summary>
        /// Reads from a text file and populates the list view
        /// </summary>
        public static ObservableCollection<Loan> GetLoans()
        {
            var loans = new ObservableCollection<Loan>();
            if (File.Exists(FilePath))
            {
                string[] input = File.ReadAllLines(FilePath);

                foreach (var item in input)
                {
                    var parts = item.Split(',');
                    int.TryParse(parts[1], out int amount);
                    var loan = new Loan(amount) { Name = parts[0], Description = parts[2] };
                    loans.Insert(0, loan);
                }
            }
            return loans;
        }
        public static void SaveLoan(params string[] loan)
        {
            var contents = new string[]
            {
                $"{loan[0]},{loan[1]},{loan[2]}"
            };

            File.AppendAllLines(FilePath, contents);
        }
    }
}
