using MyJoints.ViewModel;
using System.Collections.Generic;

namespace MyJoints.Core.Intrefaces.Repositories
{
    public interface IRepository<T>
        where T : EntityBase
    {
        IEnumerable<T> GetList(); 
        T Get(int id); 
        void Create(T item); 
        void Update(T item); 
        void Delete(int id); 
    }
}
