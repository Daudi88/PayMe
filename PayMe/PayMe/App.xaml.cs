using Xamarin.Forms;

//[assembly: ExportFont("Fluo Gums.ttf")]
//[assembly: ExportFont("Lucky Boss.ttf")]
//[assembly: ExportFont("Sweet Chili.ttf")]
namespace PayMe
{
    using PayMe.Views;
    using Xamarin.Forms;


    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
