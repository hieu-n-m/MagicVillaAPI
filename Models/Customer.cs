using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_VillaAPI.Models
{
	public class Customer
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
		public int Age { get; set; }

		[ForeignKey("VillaNumber")]
		public int VillaNo { get; set; }
		public VillaNumber VillaNumber { get; set; }

		[ForeignKey("Payment")]
		public int PaymentID { get; set; }
		public Payment Payment { get; set; }

	}
}
