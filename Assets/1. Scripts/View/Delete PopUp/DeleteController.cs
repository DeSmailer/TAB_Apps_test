using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class DeleteController : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private RestAPI _restAPI;

    public void TryDeleteData()
    {
        string str = _inputField.text;

        int id;
        if (!TextValidator.StringIsNotNullOrEmpty(str) && TextValidator.StringIsNumber(str, out id) && id > 0)
        {
            DeleteData(id);
        }
    }

    private void DeleteData(int id)
    {
        string url = UrlAPI.API + "/" + id;
        StartCoroutine(_restAPI.Delete(url, RequestHandler));
    }



    private void RequestHandler(UnityWebRequest request)
    {
        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            Debug.LogError(request.responseCode);
        }
    }
}
