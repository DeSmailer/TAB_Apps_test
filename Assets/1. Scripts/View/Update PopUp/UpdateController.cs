using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class UpdateController : RequestController
{
    [SerializeField] private TMP_InputField _idInputField;
    [SerializeField] private TMP_InputField _nameInputField;
    [SerializeField] private TMP_InputField _surnameInputField;
    [SerializeField] private TMP_InputField _ageInputField;

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
            _notificationController.DisplayError("Incorrect Id");
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
        if (TextValidator.StringIsNotNullOrEmpty(str) && TextValidator.StringIsNumber(str, out age) && age >= 0)
        {
            Debug.Log("ok");
        }
        else
        {
            id = -1;
            _notificationController.DisplayError("Incorrect Age");
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
            _notificationController.DisplayError(request.error);
        }
        else
        {
            //UserData userDataFromServer = JsonUtility.FromJson<UserData>(request.downloadHandler.text);
            _notificationController.Display(request.responseCode);
        }
    }
}
