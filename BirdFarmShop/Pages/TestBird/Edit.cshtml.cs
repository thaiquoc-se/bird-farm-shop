using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using DataAccessObjects;

namespace BirdFarmShop.Pages.TestBird
{
    public class EditModel : PageModel
    {
        private readonly DataAccessObjects.BirdFarmContext _context;

        public EditModel(DataAccessObjects.BirdFarmContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bird Bird { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Birds == null)
            {
                return NotFound();
            }

            var bird =  await _context.Birds.FirstOrDefaultAsync(m => m.BirdId == id);
            if (bird == null)
            {
                return NotFound();
            }
            Bird = bird;
           ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "UserId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bird).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BirdExists(Bird.BirdId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BirdExists(string id)
        {
          return (_context.Birds?.Any(e => e.BirdId == id)).GetValueOrDefault();
        }
    }
}
