using DG.Tweening;
using System;
using UnityEngine;

namespace DOAnimation
{
    public class DOButton : DOAnimation
    {
        private Vector3 initialScale;

        private void Awake()
        {
            IsLocked = false;
            initialScale = transform.localScale;
        }

        public void FakeClick()
        {
            Click();
        }

        public DOAnimation Click(bool lockButton = true)
        {
            if (lockButton)
            {
                if (IsLocked == false)
                {
                    IsLocked = true;
                    return ClickAnimation(() => { IsLocked = false; });
                }
                return null;
            }
            else
            {
                return ClickAnimation(() => { IsLocked = false; });
            }
        }

        private DOAnimation ClickAnimation(Action action = null)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(initialScale * 0.95f, duration * 0.3f));
            sequence.Append(transform.DOScale(initialScale * 1.05f, duration * 0.65f));
            sequence.Append(transform.DOScale(initialScale, duration * 0.05f).OnComplete(() =>
            {
                transform.localScale = initialScale;
                action?.Invoke();
                onComplete?.Invoke();
            }));
            return GetDOAnimation();
        }
    }
}
