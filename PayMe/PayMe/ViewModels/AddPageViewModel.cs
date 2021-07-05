using PayMe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PayMe.ViewModels
{
    public class AddPageViewModel : INotifyPropertyChanged
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

        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// A method that takes care of changing a property.
        /// </summary>
        /// <param name="name">Name of the property.</param>
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public AddPageViewModel()
        {
            SaveCommand = new Command(Save);
            CancelCommand = new Command(Cancel);
        }

        public async void Cancel()
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        
        public ICommand SaveCommand { get; set; }
        public async void Save()
        {
            await App.Current.MainPage.Navigation.PopModalAsync();

        }

        public int 
       
    }
}
