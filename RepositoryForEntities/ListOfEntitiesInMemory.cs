using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RepositoryForEntities
{
  /// <summary>
  /// Класс для сохранения данных в памяти.
  /// </summary>
  internal class ListOfEntitiesInMemory : IRepository<IEntity>
  {
    public string Path { private get; set; }

    private List<Abonent> abonents = new List<Abonent>();

    /// <summary>
    /// Создание сущности.
    /// </summary>
    /// <param name="entity">Сущность</param>
    public void Create(IEntity entity)
    {
      Console.Clear();
      abonents.Add(new Abonent(entity.Name, entity.Number));
    }

    /// <summary>
    /// Чтение сущности.
    /// </summary>
    public void Read()
    {
      Console.Clear();
      if (abonents.Count == 0)
      {
        Console.WriteLine("Список пуст");
      }
      else
      {
        foreach (var abonent in abonents)
        {
          Console.WriteLine(abonent.Number + "    " + abonent.Name);
        }
      }
    }

    /// <summary>
    /// Обновление сущности.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    public void Update(IEntity entity)
    {
      Console.Clear();

      foreach(var abonent in abonents)
      {
        if (abonent.Number == entity.Number)
        {
          abonent.Name = entity.Name;
        }
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

      foreach (var abonent in abonents)
      {
        if (abonent.Number == entity.Number)
        {
          abonents.Remove(abonent);
          break;
        }
      }
    }
  }
}
