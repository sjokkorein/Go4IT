using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EgdeBookingSystem.Data;
using EgdeBookingSystem.Models;

namespace EgdeBookingSystem.Pages.Equipments
{
    public class DetailsModel : PageModel
    {
        private readonly EgdeBookingSystem.Data.ApplicationDbContext _context;

        public DetailsModel(EgdeBookingSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Equipment Equipment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipment = await _context.Equipment.FirstOrDefaultAsync(m => m.ID == id);

            if (Equipment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
