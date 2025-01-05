using System.ComponentModel.DataAnnotations;

namespace Application_webOracle.Models
{
	public class Employee
	{
        [Required]
        public int EmpNo { get; set; }

        [Required]
        [StringLength(50)]
        public string EName { get; set; }

        [Required]
        public string Job { get; set; }
		public int? Mgr { get; set; }
		public DateTime HireDate { get; set; }
		public decimal? Sal { get; set; }
		public decimal? Comm { get; set; }
		public int DeptNo { get; set; }
	}
}
