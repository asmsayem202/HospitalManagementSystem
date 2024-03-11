using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Library.Types;
using Microsoft.EntityFrameworkCore;

namespace HMS.Library.Models
{
	public class Transaction
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TransactionId { get; set; }

		[DataType(DataType.Date)]
		public DateTime TransactionDate { get; set; }

		public string Description { get; set; }

		[Required]
		public decimal Amount { get; set; }

		public int? SupplierID { get; set; }
		public int? DoctorID { get; set; }
		public int? NurseID { get; set; }
		public int? StaffID { get; set; }

        //Navigation Property
        public virtual Supplier? Supplier { get; set; }		
        public virtual Doctor? Doctor { get; set; }		
        public virtual Nurse? Nurse { get; set; }		
        public virtual Staff? Staff { get; set; }		

	}
}
