using Microsoft.AspNet.Mvc;
using MyJoints.Core.Intrefaces.Repositories;
using MyJoints.DataAcceess.Context;
using MyJoints.ViewModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyJoints.DataAcceess.Repositories.MsSqlDb
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly MyJointDbContext _dbContext;

        public UserRepository(MyJointDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Create(User item)
        {
            _dbContext.Users.Add(item);
            _dbContext.SaveChanges();
        }

        public override void Delete(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(m => m.Id == id);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public override User Get(int id)
        {
            return _dbContext.Users.FirstOrDefault(m => m.Id == id);
        }

        public override IEnumerable<User> GetList()
        {
            return _dbContext.Users;
        }

        public override void Update(User item)
        {
            var original = _dbContext.Users.FirstOrDefault(m => m.Id == item.Id);
            original.Birthday = item.Birthday;
            original.FirstName = item.FirstName;
            original.LastName = item.LastName;
            original.Login = item.Login;
            original.Password = item.Password;
            original.Email = item.Email;

            _dbContext.SaveChanges();
        }
    }
}
