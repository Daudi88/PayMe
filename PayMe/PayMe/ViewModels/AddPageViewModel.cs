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
    public class AddPageViewModel : BaseViewModel
    {
        public ICommand CancelCommand { get; set; }


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
    }
}
