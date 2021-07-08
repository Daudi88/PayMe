using PayMe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

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

        /// <summary>
        /// Saves the user input to a text file.
        /// </summary>
        /// <param name="loan">The user input.</param>
        public static void SaveLoan(params string[] loan)
        {
            var contents = new string[]
            {
                $"{loan[0]},{loan[1]},{loan[2]}"
            };

            File.AppendAllLines(FilePath, contents);
        }

        /// <summary>
        /// Overwriting the file with the new list of loans.
        /// </summary>
        /// <param name="loans">The list of loans.</param>
        public static void DeleteLoan(ObservableCollection<Loan> loans)
        {
            var content = new List<string>();
            foreach (var loan in loans)
            {
                content.Add($"{loan.Name},{loan.Amount},{loan.Description}");
            }
            File.WriteAllLines(FilePath, content);
        }
    }
}
