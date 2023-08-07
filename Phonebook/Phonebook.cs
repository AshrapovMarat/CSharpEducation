using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Phonebook
{
  /// <summary>
  /// Класс для телефонной книги.
  /// </summary>
  internal class Phonebook
  {
    private static Phonebook single = null;

    string path = "Phonebook.txt";

    List<Abonent> abonents = new List<Abonent>();

    protected Phonebook() { }

    public static Phonebook Initializaton()
    {
      if (single == null)
      {
        single = new Phonebook();
      }
      return single;
    }

    /// <summary>
    /// Загрузка данных в программу из файла.
    /// </summary>
    public void LoadDataFromFile()
    {
      string line;

      if (File.Exists(path))
      {
        using (StreamReader reader = new StreamReader(path))
        {
          while (!reader.EndOfStream)
          {
            line = reader.ReadLine();
            string number = line.Substring(0, 11);
            string name = line.Substring(12);
            abonents.Add(new Abonent(name, number));
          }
        }
      }
      else
      {
        File.Create(path).Close();
      }
    }

    /// <summary>
    /// Добавление абонента в коллекцию.
    /// </summary>
    /// <param name="name">Имя абонента.</param>
    /// <param name="phoneNumber">Номер телефона абонента.</param>
    public void WriteDataToFile(string name, string phoneNumber)
    {
      int numberLength = 11;

      for (int i = 0; i < abonents.Count; i++)
      {
        if (abonents[i].PhoneNumber == phoneNumber)
        {
          throw new Exception("Номер телефона уже существует");
        }
      }

      if (phoneNumber.All(char.IsDigit) && phoneNumber.Count() == numberLength)
      {
        abonents.Add(new Abonent(name, phoneNumber));
      }
      else
      {
        throw new Exception("Количества цифр в номере телефона не равно 11 или в нем есть не только цифры.");
      }
    }

    /// <summary>
    /// Сохранение данных из коллекции в файл.
    /// </summary>
    public void SaveDataToFile()
    {
      using (StreamWriter write = new StreamWriter(path, false))
      {
        for (int i = 0; i < abonents.Count; i++)
        {
          write.WriteLine(abonents[i].PhoneNumber + " " + abonents[i].Name);
        }
      }
    }

    /// <summary>
    /// Удаление номера телефона из коллекции по имени.
    /// </summary>
    /// <param name="name">Имя абонента.</param>
    public void DeleteByUsername(string name)
    {
      for (int i = 0; i < abonents.Count; i++)
      {
        if (abonents[i].Name.ToUpper() == name.ToUpper())
        {
          abonents.RemoveAt(i);
          return;
        }
      }
      throw new Exception("Абонент не найден");
    }
    
    /// <summary>
    /// Удаление номера телефона из коллекции по номеру телефона.
    /// </summary>
    /// <param name="phoneNumber">Номер телефона абонента.</param>
    public void DeleteByPhoneNumber(string phoneNumber)
    {
      for (int i = 0; i < abonents.Count; i++)
      {
        if (abonents[i].PhoneNumber == phoneNumber)
        {
          abonents.RemoveAt(i);
          return;
        }
      }
      throw new Exception ("Номер не найден");
    }

    /// <summary>
    /// Получение имя пользователя по номеру телефона.
    /// </summary>
    /// <param name="phoneNumber">Номер телефона абонента.</param>
    /// <returns>Имя абонента.</returns>
    public string GetUsername(string phoneNumber)
    {
      for (int i = 0; i < abonents.Count; i++)
      {
        if (abonents[i].PhoneNumber.ToUpper() == phoneNumber.ToUpper())
        {
          return abonents[i].Name;
        }
      }
      throw new Exception("Абонент не найден");
    }

    /// <summary>
    /// Получение номера телефона по имени пользователя.
    /// </summary>
    /// <param name="Name">Имя абонента.</param>
    /// <returns>Номер телефона абонента.</returns>
    public string GetPhoneNumber(string Name)
    {
      for (int i = 0; i < abonents.Count; i++)
      {
        if (abonents[i].Name.ToUpper() == Name.ToUpper())
        {
          return abonents[i].PhoneNumber;
        }
      }
      throw new Exception("Абонент не найден");
    }

    /// <summary>
    /// Выводит номера телефонов и имена абонентов.
    /// </summary>
    public void GetAbonent()
    {
      for (int i = 0; i < abonents.Count; i++)
      {
        Console.WriteLine(abonents[i].PhoneNumber + "   " + abonents[i].Name);
      }
    }
  }
}
