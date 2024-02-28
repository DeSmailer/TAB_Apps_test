using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class RefreshController : RequestController
{
    [SerializeField] private InfoButton _infoButtonPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private TMP_InputField _inputField;

    [SerializeField] private InfoPopUp _infoPopUp;

    private const string NOT_FOUND = "Not found";

    public void TryRefreshData()
    {
        foreach (Transform child in _container)
        {
            GameObject.Destroy(child.gameObject);
        }

        string str = _inputField.text;
        if (!TextValidator.StringIsNotNullOrEmpty(str))
        {
            GetAllUsers();
        }

        int id;
        if (TextValidator.StringIsNotNullOrEmpty(str) && TextValidator.StringIsNumber(str, out id) && id > 0)
        {
            GetUser(id);
        }
    }

    private void GetUser(int id)
    {
        string url = UrlAPI.API;
        if (id != -1)
        {
            url += "/" + id;
            StartCoroutine(_restAPI.GetUser(url, PrintUserInfo));
        }
    }

    private void GetAllUsers()
    {
        StartCoroutine(_restAPI.GetAll(UrlAPI.API, PrintUsersInfo));
    }

    private void PrintUsersInfo(UnityWebRequest request)
    {
        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            _notificationController.DisplayError(request.error);
        }
        else
        {
            if (request.responseCode == 200)
            {
                string json = "{\"usersData\":" + request.downloadHandler.text + "}";
                UsersData usersData = JsonUtility.FromJson<UsersData>(json);
                foreach (var userData in usersData.usersData)
                {
                    AddElementToContainer(userData);
                }
            }
            _notificationController.Display(request.responseCode);
        }
    }

    private void PrintUserInfo(UnityWebRequest request)
    {
        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            _notificationController.DisplayError(request.error);
        }
        else
        {
            string json = request.downloadHandler.text;
            if (request.responseCode == 200)
            {
                UserData userData = JsonUtility.FromJson<UserData>(json);
                AddElementToContainer(userData);
            }
            _notificationController.Display(request.responseCode);
        }
    }

    private void AddElementToContainer(UserData userData)
    {
        InfoButton infoButton = Instantiate(_infoButtonPrefab, _container);
        infoButton.Initialize(userData);

        infoButton.gameObject.GetComponent<InfoButtonView>().Initialize(_infoPopUp);
    }
}
