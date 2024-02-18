using System.Windows.Input;

namespace MauiApp9;

public partial class ItemsPage : ContentPage, IQueryAttributable
{
    private string myName;
    private List<Person> people; // Добавляем список людей

    public ItemsPage()
    {
        InitializeComponent();

        // Инициализация статического списка людей
        InitializePeopleList();

        // Привязка списка людей к ListView
        listView.ItemsSource = people;

        // Инициализация команды поиска
        searchBar.SearchCommand = new Command<string>(Search);
    }

    private void InitializePeopleList()
    {
        people = new List<Person>
    {
        new Person { Name = "Иван Иванов", City = "Москва", Age = 25, Photo = "ivan_ivanov.jpg" },
        new Person { Name = "Анна Петрова", City = "Санкт-Петербург", Age = 30, Photo = "anna_petrova.jpg" },
        new Person { Name = "Дмитрий Смирнов", City = "Екатеринбург", Age = 22, Photo = "dmitry_smirnov.jpg" },
        new Person { Name = "Екатерина Ильина", City = "Нижний Новгород", Age = 35, Photo = "ekaterina_ilina.jpg" },
        new Person { Name = "Алексей Зайцев", City = "Казань", Age = 28, Photo = "alexey_zaytsev.jpg" },
        new Person { Name = "Наталья Кузнецова", City = "Самара", Age = 31, Photo = "natalia_kuznetsova.jpg" },
        new Person { Name = "Игорь Павлов", City = "Ростов-на-Дону", Age = 21, Photo = "igor_pavlov.jpg" },
        new Person { Name = "Ольга Морозова", City = "Уфа", Age = 29, Photo = "olga_morozova.jpg" },
        new Person { Name = "Сергей Васильев", City = "Воронеж", Age = 33, Photo = "sergey_vasiliev.jpg" },
        new Person { Name = "Марина Федорова", City = "Пермь", Age = 26, Photo = "marina_fedorova.jpg" },
        new Person { Name = "Павел Козлов", City = "Омск", Age = 24, Photo = "pavel_kozlov.jpg" },
        new Person { Name = "Елена Степанова", City = "Тюмень", Age = 32, Photo = "elena_stepanova.jpg" },
        new Person { Name = "Артем Никитин", City = "Красноярск", Age = 23, Photo = "artem_nikitin.jpg" },
        new Person { Name = "Ирина Волкова", City = "Иркутск", Age = 34, Photo = "irina_volkova.jpg" },
        new Person { Name = "Владимир Соколов", City = "Новосибирск", Age = 29, Photo = "vladimir_sokolov.jpg" },
        new Person { Name = "Павел Николаев", City = "Самара", Age = 33, Photo = "pavel_nikolaev.jpg" },
        new Person { Name = "Екатерина Лебедева", City = "Ростов-на-Дону", Age = 28, Photo = "ekaterina_lebedeva.jpg" },
        new Person { Name = "Никита Зайцев", City = "Омск", Age = 26, Photo = "nikita_zaytsev.jpg" },
        new Person { Name = "Алена Михайлова", City = "Краснодар", Age = 25, Photo = "alena_mikhailova.jpg" },
        new Person { Name = "Глеб Попов", City = "Воронеж", Age = 29, Photo = "gleb_popov.jpg" },
        new Person { Name = "Юлия Козлова", City = "Иркутск", Age = 31, Photo = "yulia_kozlova.jpg" },
        new Person { Name = "Игорь Степанов", City = "Калининград", Age = 27, Photo = "igor_stepanov.jpg" },
        new Person { Name = "Марина Антонова", City = "Хабаровск", Age = 26, Photo = "marina_antonova.jpg" },
        new Person { Name = "Сергей Григорьев", City = "Томск", Age = 30, Photo = "sergey_grigoriev.jpg" },
        new Person { Name = "Алина Сидорова", City = "Саратов", Age = 23, Photo = "alina_sidorova.jpg" },
        // Добавьте еще людей по аналогии
    };
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.Keys.Contains("name"))
        {
            myName = query["name"].ToString();
            txtHello.Text = $"Привет, {myName}!";
        }

        if (query.Keys.Contains("today"))
        {
            var date1 = Convert.ToDateTime(query["today"].ToString());
            txtToday.Text = date1.ToShortDateString();
        }
    }

    // Добавьте свойство для привязки в XAML
    public ICommand SearchCommand => new Command<string>((string query) =>
     Search(query));

    private void Search(string query)
    {
        // Фильтрация списка по запросу
        var filteredPeople = string.IsNullOrEmpty(query) ? people : people.FindAll(p => p.Name.Contains(query));
        listView.ItemsSource = filteredPeople;
    }

    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        // Отображение информации о выбранном пользователе
        var selectedPerson = (Person)e.SelectedItem;
        infoName.Text = $"ФИО: {selectedPerson.Name}";
        infoCity.Text = $"Город: {selectedPerson.City}";
        infoAge.Text = $"Возраст: {selectedPerson.Age} лет";
        infoPhoto.Source = selectedPerson.Photo;

        // Отображение блока информации
        infoLayout.IsVisible = true;

        // Сброс выбора в ListView
        listView.SelectedItem = null;
    }

    // Оставьте класс Person в том же файле или переместите в отдельный файл
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