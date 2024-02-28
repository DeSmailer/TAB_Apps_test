using UnityEngine;

namespace DOAnimation
{
    public abstract class DOWindow : DOAnimation
    {
        protected Vector3 startScale;
        [SerializeField] protected GameObject target;

        protected virtual void Initialize()
        {
            if (target == null)
            {
                target = gameObject;
            }
            startScale = /*Vector3.one;*/ target.transform.localScale;
        }
    }
}
