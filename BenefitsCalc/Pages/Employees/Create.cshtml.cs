using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BenefitsCalc.Data;
using BenefitsCalc.Models;

namespace BenefitsCalc.Pages.Employees {
	public class CreateModel : PageModel {
		private readonly BenefitsCalc.Data.BenefitsCalcContext _context;

		public CreateModel(BenefitsCalc.Data.BenefitsCalcContext context) {
			_context = context;
		}

		public IActionResult OnGet() {
			return Page();
		}

		[BindProperty]
		public Employee Employee { get; set; }

		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD


		//IActionResult or Task<IActionResult> requires return
		//Thing<Type> = Thing(Of Type)
		public async Task<IActionResult> OnPostAsync() {
			if (!ModelState.IsValid) {
				return Page();
			}

			Employee = _context.CalcBenefits(Employee);
				 
			_context.Employee.Add(Employee);
			await _context.SaveChangesAsync();

			return RedirectToPage("../Index");
		}
	}
}
