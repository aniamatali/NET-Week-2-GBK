using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace World_Travel_Blog.Models
{
	[Table("Locations")]
	public class Location
	{
		[Key]
		public int LocationId { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Experience> Experiences { get; set; }
	}
}