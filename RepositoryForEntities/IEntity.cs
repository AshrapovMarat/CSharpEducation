using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryForEntities
{
  /// <summary>
  /// Интерфейс определяет сущность.
  /// </summary>
  internal interface IEntity
  {
    /// <summary>
    /// Номер телефона.
    /// </summary>
    string Number { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    string Name { get; set; }
  }
}
