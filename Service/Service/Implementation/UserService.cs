using Domain.Model;
using Repository;
using Service.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Implementation
{
    public class UserService : IUser
    {
        private readonly AppDbContext _dbContext;
        public UserService(AppDbContext dbContext) { 
            this._dbContext = dbContext;
        }

        public List<User> GetAllRepo()
        {
            return this._dbContext.tblUser.ToList();
            // throw new NotImplementedException();
        }

        public User GetSingleRepo(long id)
        {
            // return this._dbContext.tblUser.Where(x => x.userId == id).FirstOrDefault();
            return this._dbContext.tblUser.Find(id);
            // throw new NotImplementedException();
        }


        public string AddUserRepo(User user)
        {
            try
            {
                this._dbContext.tblUser.Add(user);
                this._dbContext.SaveChanges();
                return "Success";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

            // throw new NotImplementedException();
        }




        public string RemoveUser(long id)
        {
            try
            {
                var user = this._dbContext.tblUser.Find(id);
                this._dbContext.Remove(user);
                this._dbContext.SaveChanges();
                return "Successfully Removed";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            // throw new NotImplementedException();
        }

        public string UpdateUserRepo(User user)
        {
            try
            {
                var userValue = this._dbContext.tblUser.Find(user.userId);
                if (userValue != null) { 
                    userValue.userName = user.userName;
                    this._dbContext.SaveChanges();
                    return "Successfully Updated";
                }
                else
                    return "No Record(s) Found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            // throw new NotImplementedException();
        }
    }
}
