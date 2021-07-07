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
using PayMe.Services;

namespace PayMe.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        // An ObservableCollection listens to changes and updates itself in the view.
        private ObservableCollection<Loan> loans;
        public ObservableCollection<Loan> Loans
        {
            get => loans;
            set => SetProperty(ref loans, value);
        }

        private Loan selectedLoan;
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
            Loans = DataService.GetLoans();

            AddCommand = new Command(AddNewLoan);
            LogOutCommand = new Command(LogOut);
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
