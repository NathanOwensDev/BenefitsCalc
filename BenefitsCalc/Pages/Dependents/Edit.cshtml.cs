using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BenefitsCalc.Data;
using BenefitsCalc.Models;

namespace BenefitsCalc.Pages.Dependents {
	public class EditModel : PageModel {
		private readonly BenefitsCalc.Data.BenefitsCalcContext _context;
		public List<SelectListItem> EmployeeIDOptions { get; set; }

		public EditModel(BenefitsCalc.Data.BenefitsCalcContext context) {
			_context = context;
		}

		[BindProperty]
		public Dependent Dependent { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id) {
			if (id == null) {
				return NotFound();
			}

			var d = HttpContext.Request.Query;

			Dependent = await _context.Dependent.FirstOrDefaultAsync(m => m.ID == id);

			if (Dependent == null) {
				return NotFound();
			}
			return Page();
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync() {
			if (!ModelState.IsValid) {
				return Page();
			}

			_context.Attach(Dependent).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
				_context.UpdateEmployee(_context.GetEmployeeByID(Dependent.EmployeeID));
			} catch (DbUpdateConcurrencyException) {
				if (!DependentExists(Dependent.ID)) {
					return NotFound();
				} else {
					throw;
				}
			}

			return RedirectToPage("../Index");
		}

		private bool DependentExists(int id) {
			return _context.Dependent.Any(e => e.ID == id);
		}
	}
}
