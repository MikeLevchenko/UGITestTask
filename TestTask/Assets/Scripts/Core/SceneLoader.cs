using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestTask.Core
{
    public class SceneLoader : MonoBehaviour
    {
        public event Action<SceneName> onSceneLoaded;

        private SceneName _loadingScene;
        private bool _isLoading;

        public void Init()
        {
            SceneManager.sceneLoaded += (scene, mode) => SceneLoaded();
        }

        public void LoadScene(SceneName scene)
        {
            if (!_isLoading)
            {
                _isLoading = true;
                SceneManager.LoadScene(GetSceneName(scene));
            }
        }

        private void SceneLoaded()
        {
            _isLoading = false;
            onSceneLoaded?.Invoke(_loadingScene);
        }

        private string GetSceneName(SceneName name)
        {
            switch (name)
            {
                case SceneName.Splash:
                    return Utility.Globals.Splash;
                case SceneName.Main:
                    return Utility.Globals.Main;
                default:
                    throw new Exception("Wrong scene name");
            }
        }

        public enum SceneName
        {
            Splash,
            Main
        }
    }
}
