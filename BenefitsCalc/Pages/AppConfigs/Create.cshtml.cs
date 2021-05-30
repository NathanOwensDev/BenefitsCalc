using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BenefitsCalc.Data;
using BenefitsCalc.Models;

namespace BenefitsCalc.Pages.AppConfigs
{
    public class CreateModel : PageModel
    {
        private readonly BenefitsCalc.Data.BenefitsCalcContext _context;

        public CreateModel(BenefitsCalc.Data.BenefitsCalcContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AppConfig AppConfig { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Config.Add(AppConfig);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
