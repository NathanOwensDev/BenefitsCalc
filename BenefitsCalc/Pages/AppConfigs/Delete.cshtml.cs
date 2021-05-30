using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BenefitsCalc.Data;
using BenefitsCalc.Models;

namespace BenefitsCalc.Pages.AppConfigs
{
    public class DeleteModel : PageModel
    {
        private readonly BenefitsCalc.Data.BenefitsCalcContext _context;

        public DeleteModel(BenefitsCalc.Data.BenefitsCalcContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AppConfig AppConfig { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppConfig = await _context.Config.FirstOrDefaultAsync(m => m.ID == id);

            if (AppConfig == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppConfig = await _context.Config.FindAsync(id);

            if (AppConfig != null)
            {
                _context.Config.Remove(AppConfig);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
