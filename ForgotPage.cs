//using MediaPlayer;

namespace MauiApp9;

public partial class ForgotPage : ContentPage
{
    public ForgotPage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtName.Text))
        {
            DisplayAlert("Успех", "Ожидайте", "OK");
            // Ваш код ожидания ответа...
        }
        else
        {
            DisplayAlert("Ошибка", "Пользователь не найден, проверьте введенные данные", "OK");
        }
    }
}