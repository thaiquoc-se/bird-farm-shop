using BusinessObjects.DTOs;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IUserRepository
    {
        List<UserDTO> GetAllUsers();
        UserDTO GetUserByID(string id);

        void AddNew(UserDTO user);
        void Update(TblUser user);

        void Delete(string id);
    }
}
