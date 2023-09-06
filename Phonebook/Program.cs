namespace Phonebook
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Phonebook phonebook = Phonebook.Initializaton();
      phonebook.LoadDataFromFile();
      while (true)
      {
        Console.Clear();
        Console.WriteLine($"Если хотите добавить новый номер нажмите 1.\nЕсли хотите удалить номер телефона нажмите 2. \nЕсли хотите найти человека по номеру телефона нажмите 3. " +
          $"\nДля получение всех абонентов из телефонной книги нажмите 4. \nЕсли хотите сохранить все изменения нажмите 5. \nДля выхода из приложения нажмите 6.");

        var key = Console.ReadKey().Key;

        if (key == ConsoleKey.D1)
        {
          AddAbonent(phonebook);
        }
        else if (key == ConsoleKey.D2)
        {
          DeleteAbonent(phonebook);
        }
        else if (key == ConsoleKey.D3)
        {
          SearchAbonent(phonebook);
        }
        else if (key == ConsoleKey.D4)
        {
          GetAbonentFromPhonebook(phonebook);
        }
        else if (key == ConsoleKey.D5)
        {
          SaveEverythingToAFile(phonebook);
        }
        else if ( key == ConsoleKey.D6)
        {
          Environment.Exit(0);
        }
      }
    }

    /// <summary>
    /// Метод для добавления абонента.
    /// </summary>
    /// <param name="phonebook">Класс отвечающий за телефонную книгу.</param>
    static void AddAbonent(Phonebook phonebook)
    {
      Console.Clear();
      Console.Write("Введите имя пользователя: ");
      string username = Console.ReadLine().Trim();
      Console.Write("Введите номер пользователя: ");
      string phoneNumber = Console.ReadLine().Trim();
      Console.WriteLine("Нажмите клавишу 1 для добавления абонента и выхода в главное меню. \nНажмите клавише 2 для выхода в главное меню без его добавления.");
      ConsoleKey key = Console.ReadKey(true).Key;

      if (key == ConsoleKey.D1)
      {
        try
        {
          phonebook.WriteDataToFile(username, phoneNumber);
        }
        catch(Exception ex) 
        {
          Console.WriteLine(ex.Message);
        }
      }
      else if (key == ConsoleKey.D2)
      {
      }
      else
      {
        Console.WriteLine("Вы ввели не верную клавишу.");
      }

      Console.WriteLine("Для продолжения нажмите любую клавишу");
      Console.ReadKey(true);
    }

    /// <summary>
    /// Метод для удаления абонента.
    /// </summary>
    /// <param name="phonebook">Класс отвечающий за телефонную книгу.</param>
    static void DeleteAbonent(Phonebook phonebook)
    {
      Console.Clear();
      Console.WriteLine("Для удаления по номеру телефона нажмите 1. \nДля удаления по имени нажмите 2.");
      ConsoleKey key = Console.ReadKey(true).Key;
      if (key == ConsoleKey.D1)
      {
        Console.Write("Введите номер телефона: ");
        string phoneNumber = Console.ReadLine().Trim();
        try
        {
          phonebook.DeleteByPhoneNumber(phoneNumber);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
      else if (key == ConsoleKey.D2)
      {
        Console.Write("Введите имя абонента: ");
        string username = Console.ReadLine().Trim();
        try
        {
          phonebook.DeleteByUsername(username);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
      else
      {
        Console.WriteLine("Вы ввели не верную клавишу.");
      }
      Console.WriteLine("Для продолжения нажмите любую клавишу");
      Console.ReadKey(true);
    }

    /// <summary>
    /// Метод для поиска абонента.
    /// </summary>
    /// <param name="phonebook">Класс отвечающий за телефонную книгу.</param>
    static void SearchAbonent(Phonebook phonebook)
    {
      Console.Clear();
      Console.WriteLine("Если хотите найти человека по номеру телефона нажмите 1. " +
        $"\nЕсли хотите найти человека по имени нажмите 2.");
      ConsoleKey key = Console.ReadKey(true).Key;
      if (key == ConsoleKey.D1)
      {
        Console.Write("Введите номер телефона: ");
        string phoneNumber = Console.ReadLine().Trim();
        Console.WriteLine(phonebook.GetUsername(phoneNumber));
      }
      else if (key == ConsoleKey.D2)
      {
        Console.Write("Введите имя абонента: ");
        string username = Console.ReadLine().Trim();
        Console.WriteLine(phonebook.GetPhoneNumber(username));
      }
      else
      {
        Console.WriteLine("Вы ввели не верную клавишу.");
      }
      Console.WriteLine("Для продолжения нажмите любую клавишу");
      Console.ReadKey(true);
    }

    /// <summary>
    /// Метод для сохранения изменений.
    /// </summary>
    /// <param name="phonebook">Класс отвечающий за телефонную книгу.</param>
    static void SaveEverythingToAFile(Phonebook phonebook)
    {
      Console.Clear();
      phonebook.SaveDataToFile();
      Console.WriteLine("Изменения сохранены.");
      Console.WriteLine("Для продолжения нажмите любую клавишу");
      Console.ReadKey(true);
    }

    /// <summary>
    /// Выводит все абонентов в телефонной книге.
    /// </summary>
    /// <param name="phonebook">Класс отвечающий за телефонную книгу.</param>
    static void GetAbonentFromPhonebook(Phonebook phonebook)
    {
      Console.Clear();
      Console.WriteLine("Список абонентов в телефонной книжке.");
      phonebook.GetAbonent();
      Console.WriteLine("Для продолжения нажмите любую клавишу");
      Console.ReadKey(true);
    }
  }
}