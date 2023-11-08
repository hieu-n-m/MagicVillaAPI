using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_VillaAPI.Models
{
	public class Payment
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int ServiceCost { get; set; }
		public int TravelCost { get; set; }
		public DateTime PayDate { get; set; }
		public bool IsSuccess { get; set; } = false;
	}
}
