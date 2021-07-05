using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monobehaviours // Making sure that code won't interfere with others
{
    public class NewBehaviourScript : MonoBehaviour
    {
        private Animator _animator;

        private void Awake() 
        {
            _animator = GetComponent<Animator>();
        }

        public void SetAnimations(AnimatorOverrideController overrideController)
        {
            _animator.runtimeAnimatorController = overrideController;
        }
    }
}
