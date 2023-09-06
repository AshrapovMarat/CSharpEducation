using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryForEntities
{
  internal class Abonent : IEntity
  {
    public string Number { get; set; }

    public string Name { get; set; }

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

    public Abonent(string number) : this(string.Empty, number) { }
  }
}
