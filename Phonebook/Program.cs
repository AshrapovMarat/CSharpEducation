namespace Phonebook
{
  internal class Program
  {
    static void Main(string[] args)
    {
      //Проверить что верно считывает входные данные
      Phonebook phonebook = Phonebook.Initializaton();
      phonebook.GetDataFromPhonebook();
      while (true)
      {
        Console.Clear();
        Console.WriteLine($"Если хотите добавить новый номер нажмите 1.\nЕсли хотите удалить номер телефона нажмите 2. \nЕсли хотите найти человека по номеру телефона нажмите 3. " +
          $"\nЕсли хотите сохранить все изменения нажмите 4. ");
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
          SaveEverythingToAFile(phonebook);
        }
      }
    }
    /// <summary>
    /// Метод для добавления абонента.
    /// </summary>
    /// <param name="phonebook"></param>
    static void AddAbonent(Phonebook phonebook)
    {
      Console.Clear();
      Console.Write("Введите имя пользователя: ");
      string username = Console.ReadLine().Trim();
      Console.Write("Введите номер пользователя: ");
      string phoneNumber = Console.ReadLine().Trim();
      //phonebook.PhoneNumberEntry(username, phoneNumber);
      Console.WriteLine("Нажмите клавишу 1 для добавления абонента и выхода в главное меню. \nНажмите клавише 2 для выхода в главное меню без его добавления.");
      ConsoleKey key = Console.ReadKey(true).Key;
      if (key == ConsoleKey.D1)
      {
        Console.WriteLine(phonebook.SetDataFromPhonebook(username, phoneNumber));
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
    /// <param name="phonebook"></param>
    static void DeleteAbonent(Phonebook phonebook)
    {
      Console.Clear();
      Console.WriteLine("Для удаления по номеру телефона нажмите 1. \nДля удаления по имени нажмите 2.");
      ConsoleKey key = Console.ReadKey(true).Key;
      if (key == ConsoleKey.D1)
      {
        Console.Write("Введите номер телефона: ");
        string phoneNumber = Console.ReadLine().Trim();
        Console.WriteLine(phonebook.DeleteByPhoneNumber(phoneNumber));
      }
      else if (key == ConsoleKey.D2)
      {
        Console.Write("Введите имя абонента: ");
        string username = Console.ReadLine().Trim();
        Console.WriteLine(phonebook.DeleteByUsername(username));
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
    /// <param name="phonebook"></param>
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
    /// <param name="phonebook"></param>
    static void SaveEverythingToAFile(Phonebook phonebook)
    {
      Console.Clear();
      phonebook.SaveData();
      Console.WriteLine("Изменения сохранены.");
      Console.WriteLine("Для продолжения нажмите любую клавишу");
      Console.ReadKey(true);
    }
  }
}