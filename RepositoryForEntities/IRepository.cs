using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryForEntities
{
  /// <summary>
  /// Интерфейс реализующий CRUD.
  /// </summary>
  /// <typeparam name="T">Сущность</typeparam>
  internal interface IRepository<T> where T : IEntity
  {
    /// <summary>
    /// Созадать сущность.
    /// </summary>
    /// <param name="entity"></param>
    void Create(T entity);

    /// <summary>
    /// Прочитать сущность.
    /// </summary>
    void Read();

    /// <summary>
    /// Обновить сущность.
    /// </summary>
    /// <param name="entity"></param>
    void Update(T entity);

    /// <summary>
    /// Удалить сущность.
    /// </summary>
    /// <param name="entity"></param>
    void Delete(T entity);
  }
}
