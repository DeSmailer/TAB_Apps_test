using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class NotificationController : MonoBehaviour
{
    [SerializeField] private Color32 _colorRed;
    [SerializeField] private Color32 _colorGreen;

    [SerializeField] private TMP_Text _text;

    public UnityEvent OnDisplay;


    public void DisplayError(string text)
    {
        _text.color = _colorRed;
        _text.text = "Error";

        OnDisplay?.Invoke();
    }

    public void Display(long code)
    {
        string value;
        if (ServerResponses.serverResponses.TryGetValue(code, out value))
        {
            Color32 color = SelectColor(code);
            _text.text = value;
            _text.color = color;
        }
        else
        {
            _text.color = _colorRed;
            _text.text = "Error";
        }
        OnDisplay?.Invoke();
    }

    private Color32 SelectColor(long code)
    {
        Debug.Log("code1 " + code);
        code = code / 100;
        Debug.Log("code2 " + code);
        switch (code)
        {
            case 1:
                return _colorGreen;
            case 2:
                return _colorGreen;
            case 3:
                return _colorRed;
            case 4:
                return _colorRed;
            case 5:
                return _colorRed;

            default:
                return _colorRed;
        }
    }
}
