using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenefitsCalc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BenefitsCalc.Pages
{
	 public class DetailedPaymentInfoModel : PageModel
    {
		private readonly BenefitsCalc.Data.BenefitsCalcContext _context;

		public DetailedPaymentInfoModel(BenefitsCalc.Data.BenefitsCalcContext context) {
			_context = context;
		}
		public JsonResult OnGet(int iEmpID) {
			//dynamically generate detailed per month, per check, etc. breakdown
			Employee e = _context.GetEmployeeByID(iEmpID);
			AppConfig c = _context.GetAppConfig();
			var dctFields = new Dictionary<string, string>();
			
			dctFields["Per Check Deduction"] = Math.Round((double)(e.BenefitsCost / c.PayPeriods),2).ToString();
			dctFields["Check Amount Less Deduction"] = Math.Round((double)(e.NetPay / c.PayPeriods),2).ToString();




			return new JsonResult(dctFields);
		}
	}
}
