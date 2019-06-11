using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Gameplay
{
    public class SphereTarget : Target
    {
        [SerializeField]
        private Animator _animator;

        protected override void OnClick()
        {
            _animator.SetTrigger("clicked");
            base.OnClick();
        }
    }
}
