namespace Assets.App.Scripts.Scenes.SceneWordSearch.Consts
{
    public class WordSearchResourcePaths
    {
        private const string _path = "WordSearch/Levels/";

        public static string GetLevelByIndex(int levelIndex)
        {
            return _path + levelIndex;
        }
    }
}