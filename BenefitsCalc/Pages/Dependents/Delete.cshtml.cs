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
	public class DeleteModel : PageModel {
		private readonly BenefitsCalc.Data.BenefitsCalcContext _context;

		public DeleteModel(BenefitsCalc.Data.BenefitsCalcContext context) {
			_context = context;
		}

		[BindProperty]
		public Dependent Dependent { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id) {
			if (id == null) {
				return NotFound();
			}

			Dependent = await _context.Dependent.FirstOrDefaultAsync(m => m.ID == id);

			if (Dependent == null) {
				return NotFound();
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id) {
			if (id == null) {
				return NotFound();
			}

			Dependent = await _context.Dependent.FindAsync(id);

			if (Dependent != null) {
				_context.Dependent.Remove(Dependent);
				await _context.SaveChangesAsync();

				_context.UpdateEmployee(_context.GetEmployeeByID(Dependent.EmployeeID));
			}

			return RedirectToPage("../Index");
		}
	}
}
