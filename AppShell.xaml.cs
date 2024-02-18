namespace MauiApp9
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("mainpage", typeof(MainPage));
            Routing.RegisterRoute("second", typeof(SecondPage));
            Routing.RegisterRoute("items", typeof(ItemsPage));
            Routing.RegisterRoute("forgot", typeof(ForgotPage));


        }
    }
}