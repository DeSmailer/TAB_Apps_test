using TMPro;
using UnityEngine;

public class InfoPopUp : PopUp
{
    [SerializeField] private TMP_Text _idInputField;
    [SerializeField] private TMP_Text _nameInputField;
    [SerializeField] private TMP_Text _surnameInputField;
    [SerializeField] private TMP_Text _ageInputField;

    public void Display(InfoButton infoButton)
    {
        Open();

        UserData userData = infoButton.UserData;
        _idInputField.text = "Id: " + userData.id.ToString();
        _nameInputField.text = "Name: " + userData.name;
        _surnameInputField.text = "Surname: " + userData.surname;
        _ageInputField.text = "Age: " + userData.age.ToString();
    }
}