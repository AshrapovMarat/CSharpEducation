using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryForEntities
{
  /// <summary>
  /// Класс для сохранения данных в базе данных.
  /// </summary>
  internal class ListOfEntitiesInDB : IRepository<IEntity>
  {
    private string connectionString = "";
    private List<Abonent> abonents = new List<Abonent>();

    /// <summary>
    /// Создание сущности.
    /// </summary>
    /// <param name="entity">Сущность</param>
    public void Create(IEntity entity)
    {
      string sqlExpression = $"INSERT [INTO] Abonent VALUES ('{entity.Number}', '{entity.Name}')";//дописать
      abonents.Clear();
      Console.Clear();
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        SqlCommand cmd = new SqlCommand(sqlExpression, connection);
      }
    }

    /// <summary>
    /// Чтение сущности.
    /// </summary>
    public void Read()
    {
      string sqlExpression = "SELECT [Number], [Name] FROM Abonent";//дописать
      Console.Clear();
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        SqlCommand cmd = new SqlCommand(sqlExpression, connection);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
          abonents.Add(new Abonent(reader.GetValue(0).ToString(), reader.GetValue(1).ToString()));
        }
      }
      foreach (Abonent abonent in abonents)
      {
        Console.WriteLine(abonent.Number + " " + abonent.Name);
      }
    }

    /// <summary>
    /// Обновление сущности.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    public void Update(IEntity entity)
    {
      Console.Clear();
      string sqlExpression = $"UPDATE Abonent SET Name = '{entity.Name}' WHERE Number = '{entity.Number}'";//дописать
      Console.Clear();
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        SqlCommand cmd = new SqlCommand(sqlExpression, connection);
      }
      
    }

    /// <summary>
    /// Удаление сущности.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    public void Delete(IEntity entity)
    {
      Console.Clear();
      string sqlExpression = $"DELETE Abonent WHERE Number = '{entity.Number}'";//дописать
      Console.Clear();
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        SqlCommand cmd = new SqlCommand(sqlExpression, connection);
      }
    }
  }
}
