using UnityEngine;
using DOAnimation;

public abstract class PopUp : MonoBehaviour
{
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _container;
    [SerializeField] private DOHideWindow _DOHideWindow;

    private void Awake()
    {
        InstantClose();
    }

    public void Open()
    {
        _background.SetActive(true);
        _container.SetActive(true);
    }

    public void InstantClose()
    {
        _background.SetActive(false);
        _container.SetActive(false);
    }

    public void Close()
    {
        _DOHideWindow.Hide(0.2f, _container, Vector3.one, () =>
        {
            _container.SetActive(false);
            _background.SetActive(false);
        });
    }
}
