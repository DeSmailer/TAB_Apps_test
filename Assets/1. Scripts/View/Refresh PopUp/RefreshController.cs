using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class RefreshController : MonoBehaviour
{
    [SerializeField] private InfoButton _infoButtonPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private RestAPI _restAPI;

    public void TryRefreshData()
    {
        foreach (Transform child in _container)
        {
            GameObject.Destroy(child.gameObject);
        }

        string str = _inputField.text;
        if (TextValidator.StringIsNotNullOrEmpty(str))
        {
            GetAllUsers();
        }

        int id;
        if (!TextValidator.StringIsNotNullOrEmpty(str) && TextValidator.StringIsNumber(str, out id) && id > 0)
        {
            GetUser(id);
        }
    }

    private void GetAllUsers()
    {
        StartCoroutine(_restAPI.GetAll(UrlAPI.API, PrintUsersInfo));
    }

    private void PrintUserInfo(UnityWebRequest request)
    {
        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            string json = request.downloadHandler.text;
            UserData userData = JsonUtility.FromJson<UserData>(json);
            AddElementToContainer(userData);
        }
    }
    private void PrintUsersInfo(UnityWebRequest request)
    {

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            string json = "{\"usersData\":" + request.downloadHandler.text + "}";
            UsersData usersData = JsonUtility.FromJson<UsersData>(json);
            foreach (var userData in usersData.usersData)
            {
                AddElementToContainer(userData);
            }
        }
    }

    private void AddElementToContainer(UserData userData)
    {
        InfoButton infoButton = Instantiate(_infoButtonPrefab, _container);
        infoButton.userData = userData;
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
}
