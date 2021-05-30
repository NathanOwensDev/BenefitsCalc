using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BenefitsCalc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BenefitsCalc.Data {
	public class BenefitsCalcContext : DbContext {
		public BenefitsCalcContext(DbContextOptions<BenefitsCalcContext> options) : base(options) {

		}

		public DbSet<BenefitsCalc.Models.Employee> Employee { get; set; }

		public DbSet<BenefitsCalc.Models.Dependent> Dependent { get; set; }

		public DbSet<BenefitsCalc.Models.AppConfig> Config { get; set; }

		public List<SelectListItem> GetEmployeeList(int? iEmpID = 0) {
			if (iEmpID > 0) { //only get the passed in employee by ID
				return Employee.Where(e => e.ID == iEmpID).Select(e => new SelectListItem { Value = e.ID.ToString(), Text = (e.FName + " " + e.LName) }).ToList();
			} else { //get the whole list to select from
				return Employee.Select(e => new SelectListItem { Value = e.ID.ToString(), Text = (e.FName + " " + e.LName) }).ToList();
			}
		}

		public List<Dependent> GetDependents(int iEmpID) {
			return Dependent.Where(d => d.EmployeeID == iEmpID).ToList();
		}

		public Employee GetEmployeeByID(int iEmpID) {
			return Employee.Where(e => e.ID == iEmpID).First();
		}

		public AppConfig GetAppConfig() {
			AppConfig oConfig = Config.FirstOrDefault();
			//if no config, use magic numbers defined in the scope
			if (oConfig == null) {
				oConfig = new AppConfig();
				oConfig.DefaultSalary = 52000; //2000 * 26
				oConfig.BaseBenefitsCost = 1000;
				oConfig.DependentCost = 500;
				oConfig.PayPeriods = 26;
				oConfig.DiscountPct = 0.10M;
			}
			return oConfig;
		}

		public Employee CalcBenefits(Employee oEmployee) {
			List<Dependent> lstDependents = GetDependents(oEmployee.ID);
			var oConfig = GetAppConfig();		

			oEmployee.isBenefitsDiscount = (oEmployee.FName.ToUpper().StartsWith('A') || oEmployee.LName.ToUpper().StartsWith('A') || (lstDependents.Where(d => d.LName.ToUpper().StartsWith('A') || d.FName.ToUpper().StartsWith('A')).Count() > 0));

			if (oEmployee.GrossPay == null || oEmployee.GrossPay == 0) {
				oEmployee.GrossPay = oConfig.DefaultSalary;
			}

			var totalBenefitsCost = (oConfig.BaseBenefitsCost + (lstDependents.Count() * oConfig.DependentCost));
			var discount = oEmployee.isBenefitsDiscount ? (totalBenefitsCost * oConfig.DiscountPct) : 0;

			oEmployee.BenefitsCost = Math.Round((totalBenefitsCost - discount), 2);

			oEmployee.NetPay = (oEmployee.GrossPay - oEmployee.BenefitsCost);

			return oEmployee;
		}

		public void UpdateEmployee(Employee oEmployee) {
			//called after dependent mods to calc and save employee
			oEmployee = CalcBenefits(oEmployee);
			Attach(oEmployee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			SaveChanges();
		}

	}
}
