using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Phonebook
{
  /// <summary>
  /// Класс для абонента телефонной книги.
  /// </summary>
  internal class Abonent
  {
    /// <summary>
    /// Имя абонента.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Номер телефона абонента.
    /// </summary>
    public string PhoneNumber { get; private set; }

    /// <summary>
    /// Конструктор класса абонента телефонной книги.
    /// </summary>
    /// <param name="username">Имя абонента.</param>
    /// <param name="phoneNumber">Номер телефона абонента.</param>
    public Abonent(string user, string phoneNumber)
    {
        Name = user.Trim();
        PhoneNumber = phoneNumber.Trim();
    }
  }
}
