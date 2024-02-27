using UnityEngine;
using UnityEngine.Networking;

public class CreateController : MonoBehaviour
{
    [SerializeField] private RestAPI _restAPI;

    public void CreateData()
    {
        StartCoroutine(_restAPI.Post(UrlAPI.API, RequestHandler));
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
