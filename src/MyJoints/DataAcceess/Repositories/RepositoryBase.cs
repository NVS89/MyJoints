using MyJoints.Core.Intrefaces.Repositories;
using MyJoints.ViewModel;
using System.Collections.Generic;

namespace MyJoints.DataAcceess.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        public abstract void Create(T item);
        public abstract void Delete(int id);
        public abstract T Get(int id);
        public abstract IEnumerable<T> GetList();
        public abstract void Update(T item);
    }
}
