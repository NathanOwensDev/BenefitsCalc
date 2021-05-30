using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BenefitsCalc.Pages {
	public class DependentFilterModel : PageModel {
		private readonly BenefitsCalc.Data.BenefitsCalcContext _context;

		public DependentFilterModel(BenefitsCalc.Data.BenefitsCalcContext context) {
			_context = context;
		}
		public JsonResult OnGet(int iEmpID) {
			return new JsonResult(_context.Dependent.Where(d => d.EmployeeID == iEmpID));
		}
	}
}
