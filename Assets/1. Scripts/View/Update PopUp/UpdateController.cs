using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class UpdateController : MonoBehaviour
{
    [SerializeField] private TMP_InputField _idInputField;
    [SerializeField] private TMP_InputField _nameInputField;
    [SerializeField] private TMP_InputField _surnameInputField;
    [SerializeField] private TMP_InputField _ageInputField;

    [SerializeField] private RestAPI _restAPI;

    public void TryPutData()
    {
        UserData userData = CreateUserDataFromInput();

        if (userData.id == -1)
        {
            return;
        }

        string url = UrlAPI.API + "/" + userData.id;
        StartCoroutine(_restAPI.Put(url, userData, RequestHandler));
    }

    private UserData CreateUserDataFromInput()
    {
        int id = -1;
        string name = "";
        string surname = "";
        int age = -1;

        string str = _idInputField.text;

        if (TextValidator.StringIsNotNullOrEmpty(str) && TextValidator.StringIsNumber(str, out id) && id > 0)
        {
            Debug.Log("ok");
        }
        else
        {
            id = -1;
        }

        str = _nameInputField.text;
        if (TextValidator.StringIsNotNullOrEmpty(str))
        {
            name = str;
        }

        str = _surnameInputField.text;
        if (TextValidator.StringIsNotNullOrEmpty(str))
        {
            surname = str;
        }

        str = _ageInputField.text;
        if (TextValidator.StringIsNotNullOrEmpty(str) && TextValidator.StringIsNumber(str, out age) && id > 0)
        {
            Debug.Log("ok");
        }
        else
        {
            id = -1;
        }

        UserData userData = new UserData()
        {
            id = id,
            name = name,
            surname = surname,
            age = age
        };

        return userData;
    }
    private void RequestHandler(UnityWebRequest request)
    {
        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            UserData userDataFromServer = JsonUtility.FromJson<UserData>(request.downloadHandler.text);
            Debug.Log(userDataFromServer.name);
        }
    }
}
