using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace BenefitsCalc.Models {
	public class Employee {
		[Key]
		public int ID { get; set; }
		[Display(Name = "First Name")]
		public string FName { get; set; }
		[Display(Name = "Last Name")]
		public string LName { get; set; }
		
		public decimal? GrossPay { get; set; }
		public decimal? NetPay { get; set; }		
		public decimal? BenefitsCost { get; set; }
		[Display(Name = "Benefits Discount")]
		public bool isBenefitsDiscount { get; set; }
	}
}
