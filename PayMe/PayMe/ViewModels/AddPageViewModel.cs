using PayMe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MvvmHelpers;
using System.IO;

namespace PayMe.ViewModels
{
    public class AddPageViewModel : BaseViewModel
    {
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "loans.txt");
        public ICommand CancelCommand { get; set; }

        private string nameInput;
        public string NameInput 
        {
            get => nameInput;
            set => SetProperty(ref nameInput, value);
        }

        private string amountInput;
        public string AmountInput
        {
            get => amountInput;
            set => SetProperty(ref amountInput, value);
        }

        private string descriptionInput;
        public string DescriptionInput
        {
            get => descriptionInput;
            set => SetProperty(ref descriptionInput, value);
        }

        public AddPageViewModel()
        {
            SaveCommand = new Command(Save);
            CancelCommand = new Command(Cancel);
        }

        /// <summary>
        /// Returns to mainpage without any info.
        /// </summary>
        public async void Cancel()
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// Saves the users inputs.
        /// </summary>
        public async void Save()
        {
            var contents = new string[]
            {
                $"{NameInput},{AmountInput},{DescriptionInput}"
            };

            File.AppendAllLines(filePath, contents);
            await App.Current.MainPage.Navigation.PopModalAsync();


        }
    }
}
