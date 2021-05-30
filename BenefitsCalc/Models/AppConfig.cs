using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BenefitsCalc.Models {
	public class AppConfig {
		[Key]
		public int ID { get; set; }
		public int DefaultSalary { get; set; }
		public int PayPeriods { get; set; }
		public int BaseBenefitsCost { get; set; }
		public int DependentCost { get; set; }
		[Column(TypeName = "decimal(4,4)")]
		public decimal DiscountPct { get; set; }

	}
}
