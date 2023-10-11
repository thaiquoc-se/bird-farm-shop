using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using DataAccessObjects;
using Repositories.IRepository;
using BusinessObjects.DTOs;

namespace BirdFarmShop.Pages.TestUser
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public IndexModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IList<UserDTO> TblUser { get;set; } = default!;

        public void OnGet()
        {
            //kết quả trả về đã có User ID
            TblUser = _userRepository.GetAllUsers();
        }
    }
}
