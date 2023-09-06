using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryForEntities
{
  internal interface IRepository<T> where T : IEntity
  {
    void Create(T entity);
    void Read();
    void Update(T entity);
    void Delete(T entity);

  }
}
