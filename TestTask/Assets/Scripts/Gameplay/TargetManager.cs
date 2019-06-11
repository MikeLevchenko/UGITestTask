using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Gameplay
{
    public class TargetManager : MonoBehaviour
    {
        public event System.Action<int> onTargetHit;

        [SerializeField]
        private Transform _targetStartPosition;
        [SerializeField]
        private float _randomSpawnRange;

        private List<Target> _activeTargets = new List<Target>();
        private List<Target> _targetPool = new List<Target>();

        private Vector3 _randomSpawnPosition
        {
            get
            {
                return new Vector3(Random.Range(-_randomSpawnRange, _randomSpawnRange), 0, Random.Range(-_randomSpawnRange, _randomSpawnRange)) 
                    + transform.position;
            }
        }

        public void CreateTarget(TargetData data)
        {
            Target target;
            if (_targetPool.Exists(inactiveTarget => inactiveTarget.Type == data.TargetType))
            {
                target = _targetPool.Find(inactiveTarget => inactiveTarget.Type == data.TargetType);
                _targetPool.Remove(target);
                target.transform.position = _randomSpawnPosition;
                target.gameObject.SetActive(true);
            }
            else
            {
                target = Instantiate(Resources.GameData.Instance.GetPrefab(data.TargetType),
                _randomSpawnPosition,
                _targetStartPosition.rotation,
                transform);
                target.onClick += OnTargetClicked;
                target.onHide += OnTargetHide;
            }

            target.Color = Resources.GameData.Instance.GetColor(data.TargetColor);

            target.Reward = data.TargetReward;

            _activeTargets.Add(target);
        }

        private void OnTargetClicked(int scores)
        {
            onTargetHit?.Invoke(scores);
        }

        private void OnTargetHide(Target target)
        {
            _activeTargets.Remove(target);
            _targetPool.Add(target);
            target.gameObject.SetActive(false);
            target.transform.SetAsLastSibling();
        }
    }
}
