using UnityEngine;
using TMPro;
using System;

public class DeleteController : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private RestAPI _restAPI;

    public void TryDeleteData()
    {
        string str = _inputField.text;
        if (ValidateInputField(str))
        {
            DeleteData(Int32.Parse(_inputField.text));
        }
    }

    private void DeleteData(int id)
    {
        string url = UrlAPI.API + "/" + id;
        StartCoroutine(_restAPI.Delete(url));
    }

    private bool ValidateInputField(string str)
    {
        if (String.IsNullOrEmpty(str))
            return false;

        int id;
        bool isNumber = int.TryParse(str, out id); 
        
        if (!isNumber)
            return false;

        if (id <= 0)
            return false;

        return true;
    }
}
