using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class UserDAO
    {
        private static UserDAO instance = null!;

        private static readonly object instanceLock = new object();

        private readonly BirdFarmContext _context;

        public UserDAO()
        {
            _context = new BirdFarmContext();
        }

        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }

        public List<UserDTO> GetAllUsers()
        {
            try
            {
                var users = _context.TblUsers
                .Include(t => t.District)
                .Include(t => t.Role)
                .Include(t => t.Ward).ToList();

                List<UserDTO> userList = new List<UserDTO> ();
                foreach (var user in users)
                {
                    var _user = new UserDTO()
                    {
                        UserId = user.UserId,
                        UserName = user.UserName,
                        UserAddress = user.UserAddress + ", " + user.Ward!.WardName + ", " + user.District!.DistrictName,
                        FullName = user.FullName,
                        UserStatus = user.UserStatus,
                        RoleName = user.Role.RoleName!,
                        Pass = user.Pass,
                        Email = user.Email,
                        Phone = user.Phone,
                    };

                    userList.Add(_user);
                }

                return userList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UserDTO GetUserByID(string id)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    return GetAllUsers().Where(u => u.UserId.Equals(id)).FirstOrDefault()!;
                }

                throw new Exception("User not Exist");
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);    
            }
        }
        public void AddNew(UserDTO user)
        {
            try
            {
                var tblUser = new TblUser()
                {
                    UserId = user.UserId,         
                    UserName = user.UserName,
                    RoleId = user.RoleId,
                    UserAddress = user.UserAddress,
                    WardId = user.WardId,
                    DistrictId = user.DistrictId,
                    FullName = user.FullName,
                    Email = user.Email,
                    Phone = user.Phone,
                    UserStatus = user.UserStatus,
                    Pass = user.Pass,
                };
                _context.Add(tblUser);
                _context.SaveChanges();
                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(TblUser user)
        {
            _context.Attach(user).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUserExists(user.UserId))
                {
                    throw new Exception("User not exist");
                }
                throw;
            }
        }

        public void Delete(string id) 
        {
            try
            {
                var check = TblUserExists(id);
                if (check)
                {
                    _context.Remove(check);
                    _context.SaveChanges();
                }
                throw new Exception("User not exist");
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        
        }

        private bool TblUserExists(string id)
        {
            return (_context.TblUsers?.Any(e => e.UserId == id)).GetValueOrDefault();
        }

    }
}
