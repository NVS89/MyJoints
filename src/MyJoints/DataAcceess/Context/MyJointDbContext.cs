using Microsoft.Data.Entity;
using MyJoints.ViewModel.Users;

namespace MyJoints.DataAcceess.Context
{
    public class MyJointDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}