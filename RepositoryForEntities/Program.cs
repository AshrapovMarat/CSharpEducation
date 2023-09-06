using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RepositoryForEntities
{
  internal class Program
  {
    static void Main(string[] args)
    {
      SavingEntityInMemory();
    }

    static void SavingEntityInDB()
    {
      ListOfEntitiesInDB entite = new ListOfEntitiesInDB();

      while (true)
      {
        Console.Clear();
        Console.WriteLine("1. Create\n2. Read\n3. Update\n4. Delete");
        Console.WriteLine("Введите команду: ");
        ConsoleKey key = Console.ReadKey(true).Key;
        switch (key)
        {
          // Create
          case ConsoleKey.D1:
            Console.WriteLine("Введите номер пользователя: ");
            string numberUser = Console.ReadLine();
            Console.WriteLine("Введите имя пользователя: ");
            string nameUser = Console.ReadLine();
            try
            {
              Abonent abonent = new Abonent(nameUser, numberUser);
              entite.Create(abonent);
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.ReadKey(true);
            }
            break;

          // Read
          case ConsoleKey.D2:
            Console.WriteLine();
            entite.Read();
            break;

          // Update
          case ConsoleKey.D3:
            Console.WriteLine("Введите номер пользователя для изменения его имени: ");
            numberUser = Console.ReadLine();
            Console.WriteLine("Введите новое имя пользователя");
            nameUser = Console.ReadLine();
            try
            {
              Abonent abonent = new Abonent(nameUser, numberUser);
              entite.Update(abonent);
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.ReadKey(true);
            }
            break;
          // Delete
          case ConsoleKey.D4:
            Console.WriteLine("Введите номер пользователя, которого хотите удалить: ");
            numberUser = Console.ReadLine();
            try
            {
              Abonent abonent = new Abonent(numberUser);
              entite.Delete(abonent);

            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.ReadKey(true);
            }
            break;
          default:
            Console.Clear();
            break;
        }
      }

    }

    static void SavingEntityInMemory()
    {
      ListOfEntitiesInMemory entite = new ListOfEntitiesInMemory();
      while (true)
      {
        Console.WriteLine("1. Create\n2. Read\n3. Update\n4. Delete");
        Console.WriteLine("Введите команду: ");
        ConsoleKey key = Console.ReadKey(true).Key;
        switch (key)
        {
          // Create
          case ConsoleKey.D1:
            Console.WriteLine("Введите номер пользователя: ");
            string numberUser = Console.ReadLine();
            Console.WriteLine("Введите имя пользователя: ");
            string nameUser = Console.ReadLine();
            try
            {
              Abonent abonent = new Abonent(nameUser, numberUser);
              entite.Create(abonent);
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.ReadKey(true);
            }
            break;

          // Read
          case ConsoleKey.D2:
            Console.WriteLine();
            entite.Read();
            break;

          // Update
          case ConsoleKey.D3:
            Console.WriteLine("Введите номер пользователя для изменения его имени: ");
            numberUser = Console.ReadLine();
            Console.WriteLine("Введите новое имя пользователя");
            nameUser = Console.ReadLine();
            try
            {
              Abonent abonent = new Abonent(nameUser, numberUser);
              entite.Update(abonent);
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.ReadKey(true);
            }
            break;
          // Delete
          case ConsoleKey.D4:
            Console.WriteLine("Введите номер пользователя, которого хотите удалить: ");
            numberUser = Console.ReadLine();
            try
            {
              Abonent abonent = new Abonent(numberUser);
              entite.Delete(abonent);

            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.ReadKey(true);
            }
            break;
          default:
            Console.Clear();
            break;
        }
      }
    }

    static void SavingEntityInFile()
    {
      string path = "Phonebook.txt";
      ListOfEntitiesInFile entite = new ListOfEntitiesInFile(path);
      while (true)
      {
        Console.WriteLine("1. Create\n2. Read\n3. Update\n4. Delete");
        Console.WriteLine("Введите команду: ");
        ConsoleKey key = Console.ReadKey(true).Key;
        switch (key)
        {
          // Create
          case ConsoleKey.D1:
            Console.WriteLine("Введите номер пользователя: ");
            string numberUser = Console.ReadLine();
            Console.WriteLine("Введите имя пользователя: ");
            string nameUser = Console.ReadLine();
            try
            {
              Abonent abonent = new Abonent(nameUser, numberUser);
              entite.Create(abonent);
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.ReadKey(true);
            }
            break;

          // Read
          case ConsoleKey.D2:
            Console.WriteLine();
            entite.Read();
            break;

          // Update
          case ConsoleKey.D3:
            Console.WriteLine("Введите номер пользователя для изменения его имени: ");
            numberUser = Console.ReadLine();
            Console.WriteLine("Введите новое имя пользователя");
            nameUser = Console.ReadLine();
            try
            {
              Abonent abonent = new Abonent(nameUser, numberUser);
              entite.Update(abonent);
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.ReadKey(true);
            }
            break;
          // Delete
          case ConsoleKey.D4:
            Console.WriteLine("Введите номер пользователя, которого хотите удалить: ");
            numberUser = Console.ReadLine();
            try
            {
              Abonent abonent = new Abonent(numberUser);
              entite.Delete(abonent);

            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              Console.ReadKey(true);
            }
            break;
          default:
            Console.Clear();
            break;
        }
      }
    }
  }
}
