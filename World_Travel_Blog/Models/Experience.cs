using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace World_Travel_Blog.Models
{
	[Table("Experiences")]
	public class Experience
	{
		[Key]
		public int ExperienceId { get; set; }
		public string Description { get; set; }
        public int Price { get; set; }
		public int LocationId { get; set; }
		public virtual Location Location { get; set; }
	}
}