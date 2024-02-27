using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RestAPI : MonoBehaviour
{

    //public void PutData()
    //{
    //    UserData userData = new UserData()
    //    {
    //        id = 1,
    //        name = "1",
    //        surname = "1",
    //        age = 1
    //    };
    //    string url = UrlAPI.API + "/" + userData.id;
    //    StartCoroutine(Put(url, userData));
    //}

    public IEnumerator GetAll(string url, Action<UnityWebRequest> requestHandler = null)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            requestHandler?.Invoke(request);
        }
    }

    public IEnumerator GetUser(string url, Action<UnityWebRequest> requestHandler = null)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            requestHandler?.Invoke(request);
        }
    }

    public IEnumerator Post(string url, UserData userData, Action<UnityWebRequest> requestHandler = null)
    {
        WWWForm form = new WWWForm();

        string json = JsonUtility.ToJson(userData);

        UnityWebRequest request = UnityWebRequest.Post(url, form);

        byte[] userBytes = System.Text.Encoding.UTF8.GetBytes(json);
        UploadHandler uploadHandler = new UploadHandlerRaw(userBytes);
        request.uploadHandler = uploadHandler;

        request.SetRequestHeader(RequestHeaders.ContentType, RequestHeaders.ApplicationJson);

        yield return request.SendWebRequest();

        requestHandler?.Invoke(request);
    }


    public IEnumerator Put(string url, UserData userData)
    {
        string json = JsonUtility.ToJson(userData);

        UnityWebRequest request = UnityWebRequest.Put(url, json);

        request.SetRequestHeader(RequestHeaders.ContentType, RequestHeaders.ApplicationJson);
        yield return request.SendWebRequest();

        UserData userDataFromServer = JsonUtility.FromJson<UserData>(request.downloadHandler.text);
        //DebugPrint(userDataFromServer);
    }

    public IEnumerator Delete(string url, Action<UnityWebRequest> requestHandler = null)
    {
        UnityWebRequest request = UnityWebRequest.Delete(url);

        yield return request.SendWebRequest();

        requestHandler?.Invoke(request);
    }
}

