using App.Scripts.Libs.SceneManagement.Config;
using System.Collections.Generic;

namespace App.Scripts.Libs.SceneManagement
{
    public interface ISceneNavigator
    {
        void LoadScene(string sceneId);

        public List<SceneInfo> GetAvailableSwitchScenes();
    }
}