using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using DataAccessObjects;

namespace BirdFarmShop.Pages.TestUser
{
    public class DeleteModel : PageModel
    {
        private readonly DataAccessObjects.BirdFarmContext _context;

        public DeleteModel(DataAccessObjects.BirdFarmContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TblUser TblUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.TblUsers == null)
            {
                return NotFound();
            }

            var tbluser = await _context.TblUsers.FirstOrDefaultAsync(m => m.UserId == id);

            if (tbluser == null)
            {
                return NotFound();
            }
            else 
            {
                TblUser = tbluser;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.TblUsers == null)
            {
                return NotFound();
            }
            var tbluser = await _context.TblUsers.FindAsync(id);

            if (tbluser != null)
            {
                TblUser = tbluser;
                _context.TblUsers.Remove(TblUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
