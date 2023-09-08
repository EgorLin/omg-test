using System;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;
using Assets.App.Scripts.Consts.WordSearch;
using UnityEngine;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.BuilderLevelModel.ProviderWordLevel
{
    public class ProviderWordLevel : IProviderWordLevel
    {
        public LevelInfo LoadLevelData(int levelIndex)
        {
            try
            {
                var levelInfo = GetLevelInfo(WordSearchResourcePaths.GetLevelByIndex(levelIndex));

                return levelInfo;
            } catch (Exception)
            {
                return null;
            }
        }

        private LevelInfo GetLevelInfo(string path)
        {
            var json = Resources.Load<TextAsset>(path).text;

            var levelInfo = JsonUtility.FromJson<LevelInfo>(json);

            return levelInfo;
        }
    }
}