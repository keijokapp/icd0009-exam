using System.ComponentModel.DataAnnotations;

namespace Domain
{
	public class Category : BaseEntity
	{
		public CategoryType Type { get; set; }

		[Required]
		public string Name { get; set; }
	}
}