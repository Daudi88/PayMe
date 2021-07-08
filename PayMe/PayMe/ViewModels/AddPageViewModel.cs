using MvvmHelpers;
using PayMe.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace PayMe.ViewModels
{
    public class AddPageViewModel : BaseViewModel
    {
        public ICommand CancelCommand { get; }
        public ICommand SaveCommand { get; }

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
        /// Returns to mainpage without any info being stored.
        /// </summary>
        public async void Cancel()
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        }

        /// <summary>
        /// Saves the user input.
        /// </summary>
        public async void Save()
        {
            var name = NameInput + " ";
            DataService.SaveLoan(name, AmountInput, DescriptionInput);
            await App.Current.MainPage.Navigation.PopModalAsync();
        }


    }
}
