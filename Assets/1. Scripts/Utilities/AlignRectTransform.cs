using UnityEngine;

public class AlignRectTransform : MonoBehaviour
{
    public RectTransform sourceRect;
    public RectTransform targetRect;

    void Start()
    {
        Align();
    }

    private void Update()
    {
        Align();
    }

    void Align()
    {
        targetRect.position = sourceRect.position;
        targetRect.rotation = sourceRect.rotation;
        targetRect.localScale = sourceRect.localScale;
    }
}
