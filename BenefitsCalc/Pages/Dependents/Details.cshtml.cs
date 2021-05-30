using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BenefitsCalc.Data;
using BenefitsCalc.Models;

namespace BenefitsCalc.Pages.Dependents
{
    public class DetailsModel : PageModel
    {
        private readonly BenefitsCalc.Data.BenefitsCalcContext _context;

        public DetailsModel(BenefitsCalc.Data.BenefitsCalcContext context)
        {
            _context = context;
        }

        public Dependent Dependent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dependent = await _context.Dependent.FirstOrDefaultAsync(m => m.ID == id);

            if (Dependent == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
