using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class InfoButtonView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private InfoButton _infoButton;
    [SerializeField] private Button _button;
    [SerializeField] private InfoPopUp _infoPopUp;

    private void OpenInfoPopUp()
    {

        _infoPopUp.Display(_infoButton);
    }

    public void Initialize(InfoPopUp infoPopUp)
    {
        _text.text = _infoButton.UserData.id.ToString();

        _infoPopUp = infoPopUp;
        _button.onClick.AddListener(OpenInfoPopUp);
    }
}
