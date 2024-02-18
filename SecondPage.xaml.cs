//using MediaPlayer;

namespace MauiApp9
{
    public partial class SecondPage : ContentPage
    {
        private readonly DatabaseHelper databaseHelper;

        public SecondPage()
        {
            InitializeComponent();
            databaseHelper = new DatabaseHelper(Path.Combine(FileSystem.AppDataDirectory, "database.db3"));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            User user = databaseHelper.GetUserByName(txtName.Text);

            if (user != null && user.Password == txtPass.Text)
            {
                await Shell.Current.GoToAsync($"items?name={user.Name}&today={DateTime.Now.ToShortDateString()}");
            }
            else
            {
                await DisplayAlert("Ошибка", "Неправильный логин-пароль", "OK");
            }
        }
        private void OnForgotPasswordTapped(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("forgot");
        }
    }
}