using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Core
{
    public class ApplicationManager : MonoBehaviour
    {
        [SerializeField]
        private SceneLoader _sceneLoader;

        private void Start()
        {
            DontDestroyOnLoad(this);

            _sceneLoader.onSceneLoaded += OnSceneLoaded;
            _sceneLoader.Init();
            _sceneLoader.LoadScene(SceneLoader.SceneName.Main);
        }

        private void OnSceneLoaded(SceneLoader.SceneName sceneName)
        {
            FindObjectOfType<Gameplay.GameManager>().Init();
        }
    }
}
