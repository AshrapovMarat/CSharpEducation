using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Phonebook
{
  internal class Phonebook
  {
    //rivate string username;
    private string phoneNumber;
    private static Phonebook single = null;
    string path = "Phonebook.txt";
    List<Abonent> abonents = new List<Abonent>();
    //List<string> usernames = new List<string>();
    //List<string> phoneNumbers = new List<string>();
    protected Phonebook() { }
    public static Phonebook Initializaton()
    {
      if (single == null)
      {
        single = new Phonebook();
      }
      return single;
    }
    public string Username { get; set; }

    public string PhoneNumber
    {
      get
      {
        return phoneNumber;
      }
      set
      {
        if (value.Length == 5)
        {
          phoneNumber = value;
        }
      }
    }

    /// <summary>
    /// Получение данных из файла.
    /// </summary>
    public void GetDataFromPhonebook()
    {
      string line;
      if (File.Exists(path))
      {
        using (StreamReader reader = new StreamReader(path))
        {
          while (!reader.EndOfStream)
          {
            line = reader.ReadLine();
            var words = line.Split(new char[] { ';' });
            abonents.Add(new Abonent(words[1], words[0]));
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
    /// <param name="username"></param>
    /// <param name="phoneNumber"></param>
    public string SetDataFromPhonebook(string username, string phoneNumber)
    {

      for (int i = 0; i < abonents.Count; i++)
      {
        if (abonents[i].PhoneNumber == phoneNumber)
        {
          return "Номер телефона уже существует";
        }
      }
      if (phoneNumber.All(char.IsDigit) && phoneNumber.Count() == 11 && Regex.IsMatch(username, @"^[\d \w \s]+$"))
      {
        abonents.Add(new Abonent(username, phoneNumber));
        return "Номер телефона успешно добавлен";
      }
      else
      {
        return "Количества цифр в номере телефона не равно 11 или в нем есть не только цифры или в имени пользователя есть не только цифры и буквы.";
      }
    }

    /// <summary>
    /// Сохранение данных из коллекции в файл.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="phoneNumbers"></param>
    public void SaveData()
    {
      using (StreamWriter write = new StreamWriter(path, false))
      {
        for (int i = 0; i < abonents.Count; i++)
        {
          write.WriteLine(abonents[i].PhoneNumber + ";" + abonents[i].Username);
        }
      }
    }

    /// <summary>
    /// Удаление номера телефона из коллекции по имени.
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    public string DeleteByUsername(string username)
    {
      for (int i = 0; i < abonents.Count; i++)
      {
        if (abonents[i].Username == username)
        {
          abonents.RemoveAt(i);
          return "Абонент удален";
        }
      }
      return "Абонент не найден";
    }

    /// <summary>
    /// Удаление номера телефона из коллекции по номеру телефона.
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    public string DeleteByPhoneNumber(string phoneNumber)
    {
      for (int i = 0; i < abonents.Count; i++)
      {
        if (abonents[i].PhoneNumber == phoneNumber)
        {
          abonents.RemoveAt(i);
          return "Номер удален";
        }
      }
      return "Номер не найден";
    }

    /// <summary>
    /// Получение имя пользователя по номеру телефона.
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    public string GetUsername(string phoneNumber)
    {
      for (int i = 0; i < abonents.Count; i++)
      {
        if (abonents[i].PhoneNumber == phoneNumber)
        {
          return abonents[i].Username;
        }
      }
      return "Абонент не найден";
    }

    /// <summary>
    /// Получение номера телефона по имени пользователя.
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public string GetPhoneNumber(string username)
    {
      for (int i = 0; i < abonents.Count; i++)
      {
        if (abonents[i].Username == username)
        {
          return abonents[i].PhoneNumber;
        }
      }
      return "Абонент не найден";
    }
  }
}
