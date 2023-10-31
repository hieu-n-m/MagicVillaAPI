using System.Net;

namespace MagicVilla_VillaAPI.Models
{
	public class ApiResponse
	{
		public ApiResponse()
		{
			ErrorMessages = new List<string>();
		}
		public HttpStatusCode HttpStatusCode { get; set; }
		public bool IsSuccess { get; set; } = false;
		public List<string> ErrorMessages { get; set; } = null!;
		public object Result { get; set; } = null!;
	}
}
