using DG.Tweening;
using System;
using UnityEngine;

namespace DOAnimation
{
    public class DOAnimation : MonoBehaviour
    {
        [Range(0, 3)] [SerializeField] protected float duration = 0.2f;
        public Action onComplete;
        public Action onStepComplete;
        public bool IsLocked { get; protected set; }

        protected DOAnimation GetDOAnimation()
        {
            return this;
        }
    }
}
