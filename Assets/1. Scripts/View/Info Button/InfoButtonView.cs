using UnityEngine;
using TMPro;

public class InfoButtonView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private InfoButton _infoButton;
    void Update()
    {
        _text.text = _infoButton.userData.id.ToString();
    }
}
