using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryForEntities
{
  /// <summary>
  /// Класс предсталяет абонента.
  /// </summary>
  internal class Abonent : IEntity
  {
    /// <summary>
    /// Номер телефона.
    /// </summary>
    public string Number { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Конструктор для создания абонента.
    /// </summary>
    /// <param name="name">Имя.</param>
    /// <param name="number">Номер телефона.</param>
    /// <exception cref="ArgumentException">Ошибка о не соответсвии введенного номера телефона.</exception>
    public Abonent(string name, string number)
    {
      int numberLength = 11;
      Name = name;
      if (number.All(char.IsDigit) && number.Count() == numberLength)
      {
        Number = number;
      }
      else
      {
        throw new ArgumentException("Количества цифр в номере телефона не равно 11 или в нем есть не только цифры.");
      }
    }

    /// <summary>
    /// Конструктор для создания абонента.
    /// </summary>
    /// <param name="number">Номер телефона.</param>
    public Abonent(string number) : this(string.Empty, number) { }
  }
}
