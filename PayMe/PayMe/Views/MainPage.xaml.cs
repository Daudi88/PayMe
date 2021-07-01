using System.Linq;

namespace PayMe.Views
{
    using PayMe.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        // An ObservableCollection listens to changes and updates itself.
        private ObservableCollection<Loan> loans = new ObservableCollection<Loan>();

        /// <summary>
        /// Show mainpage
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            // A few dummy loans are added to show something.
            //loans.Add(new Loan(-250) { Name = "Sanjin", Description = "Pizza" });
            //loans.Add(new Loan(-150) { Name = "Sanjin", Description = "Cola" });
            //loans.Add(new Loan(-50) { Name = "Sanjin", Description = "Snus" });
            //loans.Add(new Loan(50) { Name = "Brorsan", Description = "NOCCO" });

            //listView.ItemsSource = loans;
        }

        /// <summary>
        /// What happens when you click the button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Clicked(object sender, EventArgs e)
        {
            // A dummy loan is added.
          // loans.Insert(0,new Loan(200) { Name = "Dennis", Description = "Öl" });
        }

        /// <summary>
        /// What happens when you click the logout button.m
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logoutButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Logout", "Coming soon...", "OK");
        }

        /// <summary>
        /// When you pick a item in the list to view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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