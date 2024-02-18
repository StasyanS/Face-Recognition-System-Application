using System.Windows.Input;

namespace MauiApp9;

public partial class ItemsPage : ContentPage, IQueryAttributable
{
    private string myName;
    private List<Person> people; // ��������� ������ �����

    public ItemsPage()
    {
        InitializeComponent();

        // ������������� ������������ ������ �����
        InitializePeopleList();

        // �������� ������ ����� � ListView
        listView.ItemsSource = people;

        // ������������� ������� ������
        searchBar.SearchCommand = new Command<string>(Search);
    }

    private void InitializePeopleList()
    {
        people = new List<Person>
    {
        new Person { Name = "���� ������", City = "������", Age = 25, Photo = "ivan_ivanov.jpg" },
        new Person { Name = "���� �������", City = "�����-���������", Age = 30, Photo = "anna_petrova.jpg" },
        new Person { Name = "������� �������", City = "������������", Age = 22, Photo = "dmitry_smirnov.jpg" },
        new Person { Name = "��������� ������", City = "������ ��������", Age = 35, Photo = "ekaterina_ilina.jpg" },
        new Person { Name = "������� ������", City = "������", Age = 28, Photo = "alexey_zaytsev.jpg" },
        new Person { Name = "������� ���������", City = "������", Age = 31, Photo = "natalia_kuznetsova.jpg" },
        new Person { Name = "����� ������", City = "������-��-����", Age = 21, Photo = "igor_pavlov.jpg" },
        new Person { Name = "����� ��������", City = "���", Age = 29, Photo = "olga_morozova.jpg" },
        new Person { Name = "������ ��������", City = "�������", Age = 33, Photo = "sergey_vasiliev.jpg" },
        new Person { Name = "������ ��������", City = "�����", Age = 26, Photo = "marina_fedorova.jpg" },
        new Person { Name = "����� ������", City = "����", Age = 24, Photo = "pavel_kozlov.jpg" },
        new Person { Name = "����� ���������", City = "������", Age = 32, Photo = "elena_stepanova.jpg" },
        new Person { Name = "����� �������", City = "����������", Age = 23, Photo = "artem_nikitin.jpg" },
        new Person { Name = "����� �������", City = "�������", Age = 34, Photo = "irina_volkova.jpg" },
        new Person { Name = "�������� �������", City = "�����������", Age = 29, Photo = "vladimir_sokolov.jpg" },
        new Person { Name = "����� ��������", City = "������", Age = 33, Photo = "pavel_nikolaev.jpg" },
        new Person { Name = "��������� ��������", City = "������-��-����", Age = 28, Photo = "ekaterina_lebedeva.jpg" },
        new Person { Name = "������ ������", City = "����", Age = 26, Photo = "nikita_zaytsev.jpg" },
        new Person { Name = "����� ���������", City = "���������", Age = 25, Photo = "alena_mikhailova.jpg" },
        new Person { Name = "���� �����", City = "�������", Age = 29, Photo = "gleb_popov.jpg" },
        new Person { Name = "���� �������", City = "�������", Age = 31, Photo = "yulia_kozlova.jpg" },
        new Person { Name = "����� ��������", City = "�����������", Age = 27, Photo = "igor_stepanov.jpg" },
        new Person { Name = "������ ��������", City = "���������", Age = 26, Photo = "marina_antonova.jpg" },
        new Person { Name = "������ ���������", City = "�����", Age = 30, Photo = "sergey_grigoriev.jpg" },
        new Person { Name = "����� ��������", City = "�������", Age = 23, Photo = "alina_sidorova.jpg" },
        // �������� ��� ����� �� ��������
    };
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.Keys.Contains("name"))
        {
            myName = query["name"].ToString();
            txtHello.Text = $"������, {myName}!";
        }

        if (query.Keys.Contains("today"))
        {
            var date1 = Convert.ToDateTime(query["today"].ToString());
            txtToday.Text = date1.ToShortDateString();
        }
    }

    // �������� �������� ��� �������� � XAML
    public ICommand SearchCommand => new Command<string>((string query) =>
     Search(query));

    private void Search(string query)
    {
        // ���������� ������ �� �������
        var filteredPeople = string.IsNullOrEmpty(query) ? people : people.FindAll(p => p.Name.Contains(query));
        listView.ItemsSource = filteredPeople;
    }

    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        // ����������� ���������� � ��������� ������������
        var selectedPerson = (Person)e.SelectedItem;
        infoName.Text = $"���: {selectedPerson.Name}";
        infoCity.Text = $"�����: {selectedPerson.City}";
        infoAge.Text = $"�������: {selectedPerson.Age} ���";
        infoPhoto.Source = selectedPerson.Photo;

        // ����������� ����� ����������
        infoLayout.IsVisible = true;

        // ����� ������ � ListView
        listView.SelectedItem = null;
    }

    // �������� ����� Person � ��� �� ����� ��� ����������� � ��������� ����
    private class Person
    {
        public string Name { get; internal set; }
        public string City { get; internal set; }
        public int Age { get; internal set; }
        public string Photo { get; internal set; }
    }

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var query = e.NewTextValue;
        var filteredPeople = string.IsNullOrEmpty(query) ? people : people.FindAll(p => p.Name.Contains(query));
        listView.ItemsSource = filteredPeople;


    }
    private void addPerson_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"item");
        System.Diagnostics.Debug.WriteLine("Button clicked!");
    }
}