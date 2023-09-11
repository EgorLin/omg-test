using App.Scripts.Libs.FileManager;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;
using Assets.App.Scripts.Scenes.SceneWordSearch.Consts;
using System;
using UnityEngine;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.BuilderLevelModel.ProviderWordLevel
{
    public class ProviderWordLevel : IProviderWordLevel
    {
        public LevelInfo LoadLevelData(int levelIndex)
        {
            try
            {
                return GetLevelInfo(WordSearchResourcePaths.GetLevelByIndex(levelIndex));
            }
            catch (Exception)
            {
                return null;
            }
        }

        private LevelInfo GetLevelInfo(string path)
        {
            var json = FileManager.GetFile<TextAsset>(path).text;

            var levelInfo = JsonUtility.FromJson<LevelInfo>(json);

            return levelInfo;
        }
    }
}