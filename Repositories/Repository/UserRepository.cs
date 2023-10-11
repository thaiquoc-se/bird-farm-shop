using BusinessObjects.DTOs;
using BusinessObjects.Models;
using DataAccessObjects;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        public void AddNew(UserDTO user) => UserDAO.Instance.AddNew(user);
        

        public void Delete(string id) => UserDAO.Instance.Delete(id);
        

        public List<UserDTO> GetAllUsers() => UserDAO.Instance.GetAllUsers();

        public UserDTO GetUserByID(string id) => UserDAO.Instance.GetUserByID(id);

        public void Update(TblUser user) => UserDAO.Instance.Update(user);
        
    }
}
