using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class DeleteController : RequestController
{
    [SerializeField] private TMP_InputField _inputField;

    public void TryDeleteData()
    {
        string str = _inputField.text;

        int id;
        if (TextValidator.StringIsNotNullOrEmpty(str) && TextValidator.StringIsNumber(str, out id) && id > 0)
        {
            DeleteData(id);
        }
        else
        {
            _notificationController.DisplayError("Incorrect Id");
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
            _notificationController.DisplayError(request.error);
        }
        else
        {
            _notificationController.Display(request.responseCode);
        }
    }
}
