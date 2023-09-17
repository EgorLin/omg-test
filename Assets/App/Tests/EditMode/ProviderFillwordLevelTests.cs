using App.Scripts.Scenes.SceneFillwords.Features.ProviderLevel;
using NUnit.Framework;

namespace Tests
{
    public class ProviderFillwordLevelTests
    {
        [Test]
        public void LoadModel_ValidIndex_ReturnsGridFillWords()
        {
            var provider = new ProviderFillwordLevel();
            var validIndex = 1;

            var grid = provider.LoadModel(validIndex);

            Assert.IsNotNull(grid);
        }

        [Test]
        public void LoadModel_InvalidIndex_ReturnsNull()
        {
            var provider = new ProviderFillwordLevel();
            var invalidIndex = -1;

            var grid = provider.LoadModel(invalidIndex);

            Assert.IsNull(grid);
        }
    }
}
