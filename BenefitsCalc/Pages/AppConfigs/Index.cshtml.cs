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
    public class IndexModel : PageModel
    {
        private readonly BenefitsCalc.Data.BenefitsCalcContext _context;

        public IndexModel(BenefitsCalc.Data.BenefitsCalcContext context)
        {
            _context = context;
        }

        public IList<AppConfig> AppConfig { get;set; }

        public async Task OnGetAsync()
        {
            AppConfig = await _context.Config.ToListAsync();
        }
    }
}
