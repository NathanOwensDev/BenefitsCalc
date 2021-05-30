using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BenefitsCalc.Data;
using BenefitsCalc.Models;

namespace BenefitsCalc.Pages.Dependents {
	public class CreateModel : PageModel {
		private readonly BenefitsCalc.Data.BenefitsCalcContext _context;
		public List<SelectListItem> EmployeeIDOptions { get; set; }

		[FromQuery(Name = "EmployeeID")]
		public string EmployeeID { get; set; }

		public CreateModel(BenefitsCalc.Data.BenefitsCalcContext context) {
			_context = context;
		}

		public IActionResult OnGet() {
			if(EmployeeID != null) {
				EmployeeIDOptions = _context.GetEmployeeList(int.Parse(EmployeeID));
			} else {
				EmployeeIDOptions = _context.GetEmployeeList();
			}
			

			return Page();
		}

		[BindProperty]
		public Dependent Dependent { get; set; }

		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync() {
			if (!ModelState.IsValid) {
				return Page();
			}

			_context.Dependent.Add(Dependent);
			await _context.SaveChangesAsync();

			//calc and save employee after Dependent added to db
			_context.UpdateEmployee(_context.GetEmployeeByID(Dependent.EmployeeID));


			return RedirectToPage("../Index");
		}
	}
}
