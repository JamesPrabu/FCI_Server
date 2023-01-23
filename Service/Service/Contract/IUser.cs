using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Contract
{
    public interface IUser
    {
        List<User> GetAllRepo();
        User GetSingleRepo(long id);
        string AddUserRepo(User user);

        string UpdateUserRepo(User user);   

        string RemoveUser(long id); 

    }
}
