using System.ComponentModel.DataAnnotations;

namespace MoviesDbDotNetAngular.Server.DTOs
{
	public class TitleEntityDto
	{
		[Required]
		[MaxLength(15)]
		public string ImdbId { get; set; }
		[Required]
		[MaxLength(100)]
		public string Title { get; set; }
	}
}
