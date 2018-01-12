using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gummi.Models
{
	[Table("Products")]
	public class Product
	{
		[Key]
		public int ProductId { get; set; }
		public string Name { get; set; }
        public int Price { get; set; }
		public virtual ICollection<Review> Reviews { get; set; }
	}
}
