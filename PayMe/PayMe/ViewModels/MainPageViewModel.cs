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
        // An ObservableCollection listens to changes and updates itself.
        private ObservableCollection<Loan> loans = new ObservableCollection<Loan>();
        
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand AddCommand;

        public MainPageViewModel()
        {
            AddCommand = new Command(AddNewLoan);
        }

        public async void AddNewLoan()
        {
            loans.Insert(0, new Loan(200) { Name = "Dennis", Description = "Öl" });
        }
    }
}
