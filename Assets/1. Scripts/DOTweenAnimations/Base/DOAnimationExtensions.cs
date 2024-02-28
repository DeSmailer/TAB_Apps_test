using System;

namespace DOAnimation
{
    public static class DOAnimationExtensions
    {
        public static void OnComplete<T>(this T t, Action action) where T : DOAnimation
        {
            if (action != null && t != null)
            {
                t.onComplete = action.Invoke;
            }
        }

        public static void OnStepComplete<T>(this T t, Action action) where T : DOAnimation
        {
            if (action != null && t != null)
            {
                t.onStepComplete = action.Invoke;
            }
        }
    }
}
