using MoviesDbDotNetAngular.Server.Models;
using SqlKata.Execution;
using System.ComponentModel.DataAnnotations;

namespace MoviesDbDotNetAngular.Server.DTOs
{
	public class ImdbEntityDto
	{
		[Required]
		[MaxLength(15)]
		public string ImdbId { get; set; }
		[MaxLength(100)]
		public string Title { get; set; }
		[MaxLength(255)]
		public string ImageUrl { get; set; }
		public bool Favourite { get; set; }
		public bool Watch { get; set; }

		public static IEnumerable<ImdbEntityDto> FromImdbEntity(PaginationResult<ImdbEntity> entities)
		{
			if (entities == null)
			{
				return null;
			}

			return entities.List.Select(entity => new ImdbEntityDto
			{
				ImdbId = entity.ImdbId,
				Title = entity.Title,
				ImageUrl = entity.ImageUrl,
				Favourite = entity.Favourite,
				Watch = entity.Watch,
			});
		}

		public static IEnumerable<ImdbEntityDto> FromImdbEntity(IEnumerable<ImdbEntity> entities)
		{
			if (entities == null)
			{
				return null;
			}

			return entities.Select(entity => new ImdbEntityDto
			{
				ImdbId = entity.ImdbId,
				Title = entity.Title,
				ImageUrl = entity.ImageUrl,
				Favourite = entity.Favourite,
				Watch = entity.Watch,
			});
		}
	}
}
