using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TestTask.Gameplay;

namespace TestTask.UI
{
    public class TargetListEntry : MonoBehaviour
    {
        public event System.Action<TargetData> onSpawnClicked;

        [SerializeField]
        private Image _image;
        [SerializeField]
        private Text _reward;
        [SerializeField]
        private Button _spawnButton;

        private TargetData _targetData;

        public void Init(TargetData data)
        {
            _targetData = data;

            _image.sprite = Resources.GameData.Instance.GetSprite(data.TargetType);
            _image.color = Resources.GameData.Instance.GetColor(data.TargetColor);

            _reward.text = data.TargetReward.ToString();

            _spawnButton.onClick.AddListener(OnSpawnClicked);
        }

        private void OnSpawnClicked()
        {
            onSpawnClicked?.Invoke(_targetData);
        }
    }
}
