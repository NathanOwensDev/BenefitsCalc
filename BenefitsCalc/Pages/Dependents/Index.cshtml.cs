using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BenefitsCalc.Data;
using BenefitsCalc.Models;

namespace BenefitsCalc.Pages.Dependents {
	public class IndexModel : PageModel {
		private readonly BenefitsCalc.Data.BenefitsCalcContext _context;

		[FromQuery(Name = "EmployeeID")]
		public string EmployeeID { get; set; }

		public IndexModel(BenefitsCalc.Data.BenefitsCalcContext context) {
			_context = context;
		}

		public IList<Dependent> Dependent { get; set; }

		public async Task OnGetAsync() {
			if (EmployeeID != null && EmployeeID.Length > 0) {
				Dependent = await _context.Dependent.Where(d => d.EmployeeID == int.Parse(EmployeeID)).ToListAsync();
			} else {
				Dependent = await _context.Dependent.ToListAsync();
			}
		}
	}
}
