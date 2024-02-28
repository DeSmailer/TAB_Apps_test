using DG.Tweening;
using System;
using UnityEngine;
//using UnityEngine.UI;

namespace DOAnimation
{
    public class DOShowWindow : DOWindow
    {
        [SerializeField] private bool showOnEnable = true;
        //[SerializeField] private ScrollRect[] scrollRect;


        private void OnEnable()
        {
            if (showOnEnable)
            {
                Show(duration);
            }
        }

        private void Awake()
        {
            Initialize();
        }

        public DOAnimation Show()
        {
            return Show(duration, target, startScale);
        }

        public DOAnimation Show(float duration)
        {
            return Show(duration, target, startScale);
        }

        public DOAnimation Show(float duration, Vector3 size)
        {
            return Show(duration, target, size);
        }

        public DOAnimation Show(float duration, GameObject go)
        {
            return Show(duration, target, startScale);
        }

        public DOAnimation Show(float duration, GameObject go, Vector3 size)
        {
            if (IsLocked == false)
            {
                IsLocked = true;
                return Show(duration, go, size, () => { IsLocked = false; });
            }
            return null;
        }

        public DOAnimation Show(float duration, GameObject go, Vector3 size, Action action = null)
        {
            Debug.Log("asdasdsad");
            Debug.Log(size);
            go.transform.localScale = Vector3.zero;

            Sequence sequence = DOTween.Sequence();
            sequence.Append(go.transform.DOScale(size * 1.05f, duration * 0.8f)/*.OnUpdate(() => { ScrollToTop(); })*/);
            sequence.PrependInterval(0.1f);
            sequence.Append(go.transform.DOScale(size, duration * 0.2f)
            .OnComplete(() =>
            {
                //ScrollToTop();
                action?.Invoke();
                onComplete?.Invoke();
            }));
            //.OnUpdate(() => { ScrollToTop(); });
            return GetDOAnimation();
        }

        //private void ScrollToTop()
        //{
        //    foreach (var item in scrollRect)
        //    {
        //        if (item != null)
        //        {
        //            item.verticalNormalizedPosition = 1;
        //        }
        //    }
        //}

        //private void StopScroll(bool stop)
        //{
        //    foreach (var item in scrollRect)
        //    {
        //        if (item != null)
        //        {
        //            item.vertical = !stop;
        //        }
        //    }
        //}
    }
}
