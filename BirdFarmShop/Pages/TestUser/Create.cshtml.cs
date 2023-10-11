using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using DataAccessObjects;
using Repositories.IRepository;
using BusinessObjects.DTOs;

namespace BirdFarmShop.Pages.TestUser
{
    public class CreateModel : PageModel
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IWardRepository _wardRepository;

        public CreateModel(IUserRepository userRepository, IRoleRepository roleRepository, IDistrictRepository districtRepository, IWardRepository wardRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _districtRepository = districtRepository;
            _wardRepository = wardRepository;
        }

        public IActionResult OnGet()
        {
        ViewData["DistrictName"] = new SelectList(_districtRepository.GetDistricts(), "DistrictId", "DistrictName");
        ViewData["RoleName"] = new SelectList(_roleRepository.GetRoles(), "RoleId", "RoleName");
        ViewData["WardName"] = new SelectList(_wardRepository.GetWards(), "WardId", "WardName");
            return Page();
        }

        [BindProperty]
        public TblUser TblUser { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            UserDTO newUser = new UserDTO()
            {
                UserId = Guid.NewGuid().ToString().Substring(0, 5),
                UserName = TblUser.UserName,
                Email = TblUser.Email,
                DistrictId = TblUser.DistrictId,
                WardId = TblUser.WardId,
                Pass = TblUser.Pass,
                FullName = TblUser.FullName,
                Phone = TblUser.Phone,
                RoleId = TblUser.RoleId,
                UserAddress = TblUser.UserAddress,
                UserStatus = TblUser.UserStatus,
            };
            _userRepository.AddNew(newUser);

            return RedirectToPage("/TestUser/Index");
        }
    }
}
