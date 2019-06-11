using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestTask.UI;

namespace TestTask.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private TargetManager _targets;
        [SerializeField]
        private UIController _uiController;
        [SerializeField]
        private SoundManager _soundManager;

        public void Init()
        {
            _uiController.onTargetEntryClicked += CreateTarget;
            _targets.onTargetHit += SetScore;

            _uiController.Init();
            if (PlayerPrefs.HasKey("Score"))
            {
                _uiController.SetScore(PlayerPrefs.GetInt("Score"));
            }
            else
            {
                PlayerPrefs.SetInt("Score", 0);
            }
        }

        private void CreateTarget(TargetData data)
        {
            _targets.CreateTarget(data);
        }

        private void SetScore(int score)
        {
            int totalScore = score + PlayerPrefs.GetInt("Score");
            PlayerPrefs.SetInt("Score", totalScore);
            _uiController.SetScore(totalScore);

            _soundManager.Play();
        }
    }
}
