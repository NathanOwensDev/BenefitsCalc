using BenefitsCalc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsCalc.Pages {
	public class IndexModel : PageModel {
		private readonly BenefitsCalc.Data.BenefitsCalcContext _context;

		public IndexModel(BenefitsCalc.Data.BenefitsCalcContext context) {
			_context = context;
		}
		public IList<Dependent> Dependent { get; set; }
		public IList<Employee> Employee { get; set; }

		public async Task OnGetAsync() {
			Employee = await _context.Employee.ToListAsync();
			Dependent = await _context.Dependent.ToListAsync();
		}

		public IList<Dependent> FilterDependents(int iEmpID) {
			var l = Dependent.Where(d => d.EmployeeID == iEmpID).ToList();
			return l;
		}
	}
}
