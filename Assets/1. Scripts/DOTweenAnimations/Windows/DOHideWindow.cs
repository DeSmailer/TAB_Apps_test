using DG.Tweening;
using System;
using UnityEngine;

namespace DOAnimation
{
    public class DOHideWindow : DOWindow
    {
        private void Awake()
        {
            Initialize();
        }

        public DOAnimation Hide()
        {
            return Hide(duration, target, startScale);
        }

        public DOAnimation Hide(float duration)
        {
            return Hide(duration, target, startScale);
        }

        public DOAnimation Hide(float duration, Vector3 size)
        {
            return Hide(duration, target, size);
        }

        public DOAnimation Hide(float duration, GameObject go)
        {
            return Hide(duration, target, startScale);
        }

        public DOAnimation Hide(float duration, GameObject go, Vector3 size)
        {
            if (IsLocked == false)
            {
                IsLocked = true;
                return Hide(duration, go, size, () => { IsLocked = false; });
            }
            return null;
        }

        public DOAnimation Hide(float duration, GameObject go, Vector3 size, Action action = null)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(go.transform.DOScale(size * 1.05f, duration * 0.8f));
            sequence.PrependInterval(0.1f);
            sequence.Append(go.transform.DOScale(Vector3.zero, duration * 0.2f).OnComplete(() =>
            {
                go.transform.localScale = Vector3.zero;
                action?.Invoke();
                onComplete?.Invoke();
            }));
            return GetDOAnimation();
        }
    }
}
