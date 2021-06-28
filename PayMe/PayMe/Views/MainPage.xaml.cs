namespace PayMe.Views
{
    using PayMe.Models;
    using System;
    using System.Collections.Generic;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var loans = new List<Loan>
            {
                new Loan(-250) { Name = "Sanjin", Description = "Pizza" },
                new Loan(-150) { Name = "Sanjin", Description = "Cola" },
                new Loan(-50) { Name = "Sanjin", Description = "Snus" },
                new Loan(50) { Name = "Brorsan", Description = "NOCCO" },
            };

            listView.ItemsSource = loans;

        }



        private void addButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Add New Loan", "Coming soon...", "OK");
        }
        private void logoutButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Logout", "Coming soon...", "OK");
        }

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listView.SelectedItem == null)
                return;

            var loan = e.SelectedItem as Loan;

            await DisplayAlert("Details", loan.Description, "OK");
            listView.SelectedItem = null;
        }
    }
}