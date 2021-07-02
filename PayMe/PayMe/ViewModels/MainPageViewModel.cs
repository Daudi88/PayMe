using PayMe.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace PayMe.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // An ObservableCollection listens to changes and updates itself.
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

        public void AddNewLoan()
        {
            Loans.Insert(0, new Loan(200) { Name = "Dennis", Description = "Öl" });
        }

        public async void LogOut()
        {
            await App.Current.MainPage.DisplayAlert("Logout", "Coming soon...", "OK");
        }

        private async void ItemSelected(Loan selectedLoan)
        {
            if (SelectedLoan == null)
                return;

            await App.Current.MainPage.DisplayAlert("Details", selectedLoan.Description, "OK");
            SelectedLoan = null;
        }
    }
}
