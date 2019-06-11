using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TestTask.Gameplay;

namespace TestTask.UI
{
    public class UIController : MonoBehaviour
    {
        public event System.Action<TargetData> onTargetEntryClicked; 
        [SerializeField]
        private Text scores;
        [SerializeField]
        private TargetList _targetList;

        public void Init()
        {
            _targetList.onEntryClicked += RaiseOnTargetEntryClicked;
            _targetList.Init();

            SetScore(0);
        }

        public void SetScore(int score)
        {
            scores.text = string.Format("Score: {0}", score);
        }

        private void RaiseOnTargetEntryClicked(TargetData data)
        {
            onTargetEntryClicked?.Invoke(data);
        }
    }
}
