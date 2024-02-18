using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace MauiApp9
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class DatabaseHelper
    {
        readonly SQLiteConnection database;

        public DatabaseHelper(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<User>();

            // Заполнение базы данных при инициализации (можно убрать после первого заполнения)
            SeedDatabase();
        }

        public int InsertUser(User user)
        {
            return database.Insert(user);
        }

        public User GetUserByName(string name)
        {
            return database.Table<User>().FirstOrDefault(u => u.Name == name);
        }

        private void SeedDatabase()
        {
            // Проверяем, есть ли пользователи в базе данных
            if (database.Table<User>().Any())
                return; // Если уже есть, не добавляем

            // Добавляем несколько примеров пользователей
            var users = new List<User>
            {
                new User { Name = "Admin", Password = "password" },
                new User { Name = "User1", Password = "123456" },
                new User { Name = "User2", Password = "qwerty" }
            };

            // Вставляем пользователей в базу данных
            foreach (var user in users)
            {
                database.Insert(user);
            }
        }
    }
}