using UnityEngine;
using UnityEngine.Networking;

public class CreateController : MonoBehaviour
{
    [SerializeField] private RestAPI _restAPI;

    public void CreateData()
    {
        //���� ������� ��� ���, � ���� id, �� � ��� ����������� ����� �����������
        //���� �� ������� ����� id, �� �� ���� �������� ����� � ���� ������ �� �� ��������
        UserData userData = new UserData()
        {
            id = -1,
            name = "test -1",
            surname = "test -1",
            age = -1
        };

        StartCoroutine(_restAPI.Post(UrlAPI.API, userData, RequestHandler));
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
            Debug.Log(userDataFromServer);
        }
    }
}
