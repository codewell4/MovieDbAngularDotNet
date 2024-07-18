namespace MoviesDbDotNetAngular.Server.Models
{
	public class ImdbEntity
	{
		public int Id { get; set; }
		public string ImdbId { get; set; }
		public string Title { get; set; }
		public string ImageUrl { get; set; }
		public bool Favourite { get; set; }
		public bool Watch { get; set; }
	}
}
