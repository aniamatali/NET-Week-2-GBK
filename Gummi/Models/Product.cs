using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Gummi.Models
{
	[Table("Products")]
	public class Product
	{
		[Key]
		public int ProductId { get; set; }
		public string Description { get; set; }
    public int Price { get; set; }
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }
	}
}
