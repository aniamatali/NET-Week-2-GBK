using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gummi.Models
{
	[Table("Categories")]
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Product> Products { get; set; }
	}
}
