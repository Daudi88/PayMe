using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using PayMe.Models;

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

        public ICommand AddCommand;

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
        }

        public async void AddNewLoan()
        {
            Loans.Insert(0, new Loan(200) { Name = "Dennis", Description = "Öl" });
        }
    }
}
