using MoviesDbDotNetAngular.Server.DTOs;
using MoviesDbDotNetAngular.Server.Models;

namespace MoviesDbUnitTests
{
	[TestClass]
	public class BasicTests
	{
		[TestMethod]
		public async Task SimpleDtoTransform()
		{
			ImdbEntity entity = new ImdbEntity
			{
				Id = 1,
				Title = "Title",
				ImdbId = "tt123456789",
				ImageUrl = "SomeUrl"
			};

			var transformedEntity = ImdbEntityDto.FromImdbEntity(new List<ImdbEntity> { entity });

			Assert.IsNotNull(transformedEntity);
			Assert.AreEqual(1, transformedEntity.Count());
			Assert.AreEqual("tt123456789", transformedEntity.First().ImdbId);
		}
	}
}