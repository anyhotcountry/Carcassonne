using Carcassonne.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Services.Tests
{
    [TestFixture]
    public class TilesServiceTests
    {
        [Test]
        public async Task TestMethod1()
        {
            var target = new TilesService(new System.Uri("ms-appx:///Assets/Tiles/"));
            await target.LoadTiles();
            var tile = target.NextTile();
            Assert.That(tile.ImageUri.AbsolutePath, Does.EndWith(""));
        }
    }
}