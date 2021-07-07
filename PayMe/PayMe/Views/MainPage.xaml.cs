namespace PayMe.Views
{
    using PayMe.ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Show mainpage
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Refreshes the MainPage everytime it appears. 
        /// </summary>
        protected override void OnAppearing()
        {
           if(BindingContext is MainPageViewModel vm)
            {
                vm.GetLoans();
            }
        }
    }
}