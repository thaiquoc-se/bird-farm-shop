using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using DataAccessObjects;

namespace BirdFarmShop.Pages.TestBird
{
    public class CreateModel : PageModel
    {
        private readonly DataAccessObjects.BirdFarmContext _context;

        public CreateModel(DataAccessObjects.BirdFarmContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "UserId");
            return Page();
        }

        [BindProperty]
        public Bird Bird { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
          if (!ModelState.IsValid || Bird == null)
            {
                return Page();
            }

            

            return RedirectToPage("./Index");
        }
    }
}
