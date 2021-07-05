using PayMe.Models;
using PayMe.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace PayMe.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        /// <summary>
        /// A method that takes care of changing a property.
        /// </summary>
        /// <param name="name">Name of the property.</param>
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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

        public ICommand AddCommand { get; private set; }
        public ICommand LogOutCommand { get; private set; }


        public MainPageViewModel()
        {
            Loans = new ObservableCollection<Loan>
            {
                new Loan(-250) { Name = "Sanjin", Description = "Pizza" },
                new Loan(-150) { Name = "Sanjin", Description = "Cola" },
                new Loan(-50) { Name = "Sanjin", Description = "Snus" },
                new Loan(50) { Name = "Brorsan", Description = "NOCCO" }
            };


            AddCommand = new Command(AddNewLoan);
            LogOutCommand = new Command(LogOut);
        }

        /// <summary>
        /// Inserts a new loan at the top of the list
        /// (Not fully implemented yet. Adds a dummy loan right now).
        /// </summary>
        public async void AddNewLoan()
        {
            AddPage addPage = new AddPage();
            await App.Current.MainPage.Navigation.PushModalAsync(addPage);
            // Loans.Insert(0, new Loan(200) { Name = "Dennis", Description = "Öl" });
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
