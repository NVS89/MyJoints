using MyJoints.Core.Exceptions;
using MyJoints.Core.Intrefaces.Repositories;
using MyJoints.ViewModel.Users;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MyJoints.DataAcceess.Repositories.Memory
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private static ConcurrentDictionary<int, User> m_users = new ConcurrentDictionary<int, User>();
        private static int m_count = 0;

        public UserRepository()
        {
            if (m_users.Count == 0)
            {
                Create(new User { Id = 1, Login = "admin", Password = "MyJoints", FirstName = "Administrator", LastName = "MyJoints Andministrator", Email = "admin@myjoints.com", Birthday = DateTime.Parse("10.10.2015 00:00:00") });
            }
        }

        public override void Create(User item)
        {
            item.Id = m_count++;
            if (!m_users.TryAdd(item.Id, item))
            {
                throw new DataAccessException(String.Format("User Id:{0} already exists. You can remove or update", item.Id));
            }
        }

        public override void Delete(int id)
        {
            User user;
            if (!m_users.TryRemove(id, out user))
            {
                throw new DataAccessException(String.Format("User Id:{0} doesn't exist. You can add the user.", id));
            }
        }

        public override User Get(int id)
        {
            User result;
            m_users.TryGetValue(id, out result);

            return result;
        }

        public override IEnumerable<User> GetList()
        {
            IEnumerable<User> result = m_users.Values;
            return result;
        }

        public override void Update(User item)
        {
            m_users[item.Id] = item;
        }
    }
}
