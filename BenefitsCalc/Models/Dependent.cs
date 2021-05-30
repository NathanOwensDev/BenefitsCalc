using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BenefitsCalc.Models {
	public class Dependent {
		[Key]
		public int ID { get; set; }
		public int EmployeeID { get; set; }
		[Display(Name = "First Name")]
		public string FName { get; set; }
		[Display(Name = "Last Name")]
		public string LName { get; set; }

		
	}
}
