using Xamarin.Forms;

[assembly: ExportFont("Lucky Boss.ttf")]
[assembly: ExportFont("Sweet Chili.ttf")]
[assembly: ExportFont("Caveat-Regular.ttf")]
[assembly: ExportFont("Caveat-Bold.ttf")]
[assembly: ExportFont("Caveat-Medium.ttf")]
[assembly: ExportFont("Caveat-SemiBold.ttf")]
[assembly: ExportFont("Bangers.ttf")]
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
