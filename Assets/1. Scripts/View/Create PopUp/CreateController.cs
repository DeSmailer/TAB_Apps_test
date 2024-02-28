using UnityEngine;
using UnityEngine.Networking;

public class CreateController : RequestController
{
    public void CreateData()
    {
        StartCoroutine(_restAPI.Post(UrlAPI.API, RequestHandler));
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
