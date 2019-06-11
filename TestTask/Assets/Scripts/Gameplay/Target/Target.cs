using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Gameplay
{
    public class Target : MonoBehaviour
    {
        public event System.Action<int> onClick;
        public event System.Action<Target> onHide;

        [SerializeField]
        private TargetData.Type _type;
        private int _reward;
        public int Reward
        {
            set
            {
                _reward = value;
            }
        }

        public TargetData.Type Type
        {
            get
            {
                return _type;
            }
        }

        public Color Color
        {
            set
            {
                GetComponent<MeshRenderer>().material.color = value;
            }
        }

        public void OnMouseDown()
        {
            OnClick();   
        }

        protected virtual void OnClick()
        {
            onClick?.Invoke(_reward);
        }

        protected virtual void Hide()
        { 
            onHide?.Invoke(this);
        }

        protected IEnumerator HideInTime(float time)
        {
            yield return new WaitForSeconds(time);
            Hide();
        }
    }
}
