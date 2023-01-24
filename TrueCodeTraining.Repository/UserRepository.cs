using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueCode.Model;
using TrueCodeTraining.DbModel;

namespace TrueCodeTraining.Repository
{
    public class UserRepository
    {
        public UserVm AddUserData(UserVm userVm)
        {
            using(TrueCodeTrainingDbContext dbContext = new TrueCodeTrainingDbContext()) {
                var user = new User();
                user.FirstName = userVm.FirstName;
                user.LastName = userVm.LastName;
                user.UserName = userVm.UserName;
                user.Email = userVm.Email;
                user.Password = userVm.Password;
                user.Status = userVm.Status; 
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return userVm;
            }
        }
        public UserVm GetAllUser(UserVm userVm)
        {
            using(TrueCodeTrainingDbContext dbContext = new TrueCodeTrainingDbContext()) {
                return (from user in dbContext.Users where userVm.FirstName == user.FirstName || userVm.Email == user.Email
                        select new UserVm() { 
                            UserName = user.UserName,
                            Email = user.Email
                        }).FirstOrDefault();
            }
        }
        public UserVm LoginUser(UserVm userVm)
        {
            using (TrueCodeTrainingDbContext dbContext = new TrueCodeTrainingDbContext()) {
                return (from user in dbContext.Users
                        where userVm.UserName == user.UserName || userVm.Password == user.Password
                        select new UserVm() {
                            UserName = user.UserName,
                            Password = user.Password
                        }).FirstOrDefault();
            }
        }
    }
}
