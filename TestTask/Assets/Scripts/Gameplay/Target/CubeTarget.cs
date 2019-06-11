using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Gameplay
{
    public class CubeTarget : Target
    {
        [SerializeField]
        private ParticleSystem _particleSystem;

        protected override void OnClick()
        {
            _particleSystem.Play();
            GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(HideInTime(1));
            base.OnClick();
        }

        protected override void Hide()
        {
            GetComponent<MeshRenderer>().enabled = true;
            base.Hide();
        }


    }
}
