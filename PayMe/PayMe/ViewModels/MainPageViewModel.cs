using PayMe.Models;
using PayMe.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using MvvmHelpers;
using System.IO;
using System;
using System.Runtime.CompilerServices;

namespace PayMe.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "loans.txt");


        // An ObservableCollection listens to changes and updates itself in the view.
        private ObservableCollection<Loan> loans;
        public ObservableCollection<Loan> Loans
        {
            get => loans;
            set
            {
                if (loans == value)
                    return;

                loans = value;
                OnPropertyChanged(nameof(Loans));
            }
        }

        private Loan selectedLoan;
        /// <summary>
        /// 
        /// </summary>
        public Loan SelectedLoan
        {
            get => selectedLoan;
            set
            {
                if (value == selectedLoan)
                    return;

                selectedLoan = value;
                OnPropertyChanged(nameof(SelectedLoan));
                ItemSelected(SelectedLoan);
            }
        }

        public ICommand AddCommand { get; }
        public ICommand LogOutCommand { get; }

        public MainPageViewModel()
        {
            Loans = new ObservableCollection<Loan>();
            Loans = GetLoans();

            AddCommand = new Command(AddNewLoan);
            LogOutCommand = new Command(LogOut);
        }
        /// <summary>
        /// Reads from a text file and populates the list view
        /// </summary>
        private ObservableCollection<Loan> GetLoans()
        {
            var loans = new ObservableCollection<Loan>();
            if (File.Exists(filePath))
            {
                string[] input = File.ReadAllLines(filePath);

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
        /// Opens a new page where the user can add a new loan
        /// </summary>
        public async void AddNewLoan()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new AddPage());
        }

        /// <summary>
        /// Logs the user out (Not fully implemented yet. Shows an alert right now).
        /// </summary>
        public async void LogOut()
        {
            await App.Current.MainPage.DisplayAlert("Logout", "Coming soon...", "OK");
        }

        /// <summary>
        /// Lets the user see a detailed page about the loan
        /// (Not fully implemented yet. Shows an alert with
        /// some details right now)
        /// </summary>
        /// <param name="selectedLoan">The selected loan.</param>
        private async void ItemSelected(Loan selectedLoan)
        {
            if (selectedLoan == null)
                return;

            await App.Current.MainPage.DisplayAlert("Details", selectedLoan.Description, "OK");
            selectedLoan = null;
        }
    }
}
