using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RepositoryForEntities
{
  /// <summary>
  /// Класс для сохранения данных в файл.
  /// </summary>
  internal class ListOfEntitiesInFile : IRepository<IEntity>
  {
    public string Path { private get; set; }

    private List<Abonent> abonents = new List<Abonent>();

    public ListOfEntitiesInFile(string path)
    {
      Path = path;
    }

    /// <summary>
    /// Создание сущности.
    /// </summary>
    /// <param name="entity">Сущность</param>
    public void Create(IEntity entity)
    {
      Console.Clear();
      using (StreamWriter write = new StreamWriter(Path))
      {
        write.WriteLine(entity.Number + " " + entity.Name);
      }
    }

    /// <summary>
    /// Чтение сущности.
    /// </summary>
    public void Read()
    {
      Console.Clear();
      abonents.Clear();
      string line;

      if (File.Exists(Path))
      {
        using (StreamReader reader = new StreamReader(Path))
        {
          while (!reader.EndOfStream)
          {
            line = reader.ReadLine();
            if (line.Length > 10)
            {
              string number = line.Substring(0, 11);
              string name = line.Substring(12);
              abonents.Add(new Abonent(name, number));
            }
          }

          foreach (var a in abonents)
          {
            if (abonents.Count == 0)
            {
              Console.WriteLine("Список пуст");
              Console.ReadKey();
            }
            else
            {
              Console.WriteLine(a.Number + "    " + a.Name);
            }
          }
        }
      }
      else
      {
        File.Create(Path).Close();
      }
    }

    /// <summary>
    /// Обновление сущности.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    public void Update(IEntity entity)
    {
      Console.Clear();
      string line;

      if (File.Exists(Path))
      {
        using (StreamReader reader = new StreamReader(Path))
        {
          string[] text = reader.ReadToEnd().Split(new char[] { '\n' });
          for (int i = 0; i < text.Length; i++)
          {
            if (text[i].Length > 10 && text[i].Substring(0, 11).ToString() == entity.Number)
            {
              text[i] = text[i].Substring(0, 11) + " " + entity.Name;
            }
          }
          reader.Close();
          using (StreamWriter write = new StreamWriter(Path))
          {
            for (int j = 0; j < text.Length; j++)
            {
              write.WriteLine(text[j]);
            }
          }
        }
      }
      else
      {
        File.Create(Path).Close();
      }
    }

    /// <summary>
    /// Удаление сущности.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    public void Delete(IEntity entity)
    {
      Console.Clear();
      string line;

      if (File.Exists(Path))
      {
        using (StreamReader reader = new StreamReader(Path))
        {
          string[] text = reader.ReadToEnd().Split(new char[] { '\n' });
          for (int i = 0; i < text.Length; i++)
          {
            if (text[i].Length > 10 && text[i].Substring(0, 11).ToString() == entity.Number)
            {
              text[i] = null;
            }
          }
          reader.Close();
          using (StreamWriter write = new StreamWriter(Path))
          {
            for (int j = 0; j < text.Length; j++)
            {
              write.WriteLine(text[j]);
            }
          }
        }
      }
      else
      {
        File.Create(Path).Close();
      }
    }
  }
}
