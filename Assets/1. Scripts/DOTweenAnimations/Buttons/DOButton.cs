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

        //public DOAnimation Rotate(Vector3 angle, float duration, Action action = null)
        //{
        //    if (IsLocked == false)
        //    {
        //        IsLocked = true;
        //        return RotateAnimation(angle, duration, () => { IsLocked = false; });
        //    }
        //    return null;
        //}

        //public DOAnimation Rotate(float angle, float duration, Action action = null)
        //{
        //    if (IsLocked == false)
        //    {
        //        IsLocked = true;
        //        return RotateAnimation(angle, duration, () => { IsLocked = false; });
        //    }
        //    return null;
        //}

        //private void RotateVoid(Vector3 angle, float duration, Action action = null)
        //{
        //    Rotate(angle, duration, action);
        //}

        //private DOAnimation RotateAnimation(float angle, float duration, Action action = null)
        //{
        //    return Rotate(new Vector3(0, 0, angle), duration, action);
        //}

        //private DOAnimation RotateAnimation(Vector3 angle, float duration, Action action = null)
        //{

        //    transform.DORotate(angle, duration, RotateMode.LocalAxisAdd).OnComplete(() =>
        //    {
        //        action?.Invoke();
        //        onComplete?.Invoke();
        //    });

        //    return GetDOAnimation();
        //}

    }
}
