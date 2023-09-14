using App.Scripts.Scenes.SceneWordSearch.Features.Level.BuilderLevelModel;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class FactoryLevelModelTests
    {
        [Test]
        public void Create_ValidLevelInfo_ReturnsLevelModel()
        {
            var factory = new FactoryLevelModel();
            var levelInfo = new LevelInfo
            {
                words = new List<string> { "word1", "word2" }
            };
            var levelNumber = 1;
            var mock = new List<char> { 'w', 'o', 'r', 'd', '1', '2' };

            var result = factory.Create(levelInfo, levelNumber);

            Assert.IsNotNull(result);
            Assert.AreEqual(levelNumber, result.LevelNumber);
            Assert.AreEqual(levelInfo.words, result.Words);
            Assert.AreEqual(result.InputChars, mock);
        }

        [Test]
        public void Create_NullLevelInfo_ReturnsNull()
        {
            var factory = new FactoryLevelModel();
            LevelInfo levelInfo = null;
            var levelNumber = 1;

            var result = factory.Create(levelInfo, levelNumber);

            Assert.IsNull(result);
        }

        [Test]
        public void Create_NullWordsList_ReturnsNull()
        {
            var factory = new FactoryLevelModel();
            var levelInfo = new LevelInfo { words = null };
            var levelNumber = 1;

            var result = factory.Create(levelInfo, levelNumber);

            Assert.IsNull(result);
        }
    }
}
