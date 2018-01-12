using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Gummi.Models
{
	[Table("Reviews")]
	public class Review
	{
		[Key]
		public int ReviewId { get; set; }
		public string Description { get; set; }
    public int Price { get; set; }
		public int ProductId { get; set; }
		public string ReviewInfo {get; set;}
		public virtual Product Product { get; set; }
	}
}
