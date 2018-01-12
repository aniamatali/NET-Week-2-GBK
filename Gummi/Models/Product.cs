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



        public override bool Equals(System.Object otherProduct)
        {
            if (!(otherProduct is Product))
            {
                return false;
            }
            else
            {
                Product newItem = (Product)otherProduct;
                return this.ProductId.Equals(newItem.ProductId);
            }
        }

        public override int GetHashCode()
        {
            return this.ProductId.GetHashCode();
        }
    }
}
