using MvvmHelpers;
using PayMe.Models;
using PayMe.Services;
using PayMe.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PayMe.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public Command<Loan> DeleteCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand LogOutCommand { get; }

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
                {
                    return;
                }

                selectedLoan = value;
                OnPropertyChanged(nameof(SelectedLoan));
                ItemSelected(SelectedLoan);
            }
        }

        public MainPageViewModel()
        {
            Loans = new ObservableCollection<Loan>();
            DeleteCommand = new Command<Loan>(DeleteLoan);
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
            {
                return;
            }

            await App.Current.MainPage.DisplayAlert("Details", selectedLoan.Description, "OK");
        }

        /// <summary>
        /// Method to get loans from DataServic
        /// </summary>
        public void GetLoans()
        {
            Loans = DataService.GetLoans();
        }

        /// <summary>
        /// Method to remove a loan from the list.
        /// </summary>
        /// <param name="loan">The loan to remove.</param>
        void DeleteLoan(Loan loan)
        {
            Loans.Remove(loan);
            DataService.DeleteLoan(Loans);
        }
    }
}
