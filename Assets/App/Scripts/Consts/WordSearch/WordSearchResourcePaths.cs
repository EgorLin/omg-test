namespace Assets.App.Scripts.Consts.WordSearch
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