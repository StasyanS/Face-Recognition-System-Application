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
            DisplayAlert("�����", "��������", "OK");
            // ��� ��� �������� ������...
        }
        else
        {
            DisplayAlert("������", "������������ �� ������, ��������� ��������� ������", "OK");
        }
    }
}