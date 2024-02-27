using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RestAPI : MonoBehaviour
{
    //public void PostData()
    //{
    //    UserData userData = new UserData()
    //    {
    //        name = "sdfsd",
    //        surname = "sdfsdf",
    //        age = 123
    //    };

    //    StartCoroutine(Post(UrlAPI.API, userData));
    //}

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

    public IEnumerator GetAll(string url, Action<UnityWebRequest> requestHandler)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            requestHandler?.Invoke(request);

            //if (request.result == UnityWebRequest.Result.ConnectionError)
            //{
            //    Debug.LogError(request.error);
            //}
            //else
            //{
            //    string json = "{\"usersData\":" + request.downloadHandler.text + "}";
            //    UsersData usersData = JsonUtility.FromJson<UsersData>(json);
            //    DebugPrint(usersData);
            //}
        }
    }

    public IEnumerator GetUser(string url, Action<UnityWebRequest> requestHandler)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            requestHandler?.Invoke(request);
            //if (request.result == UnityWebRequest.Result.ConnectionError)
            //{
            //    Debug.LogError(request.error);
            //}
            //else
            //{
            //    string json = request.downloadHandler.text;
            //    UserData userData = JsonUtility.FromJson<UserData>(json);
            //    DebugPrint(userData);
            //}
        }
    }

    public IEnumerator Post(string url, UserData userData)
    {
        WWWForm form = new WWWForm();

        string json = JsonUtility.ToJson(userData);

        UnityWebRequest request = UnityWebRequest.Post(url, form);

        byte[] userBytes = System.Text.Encoding.UTF8.GetBytes(json);
        UploadHandler uploadHandler = new UploadHandlerRaw(userBytes);
        request.uploadHandler = uploadHandler;
        request.SetRequestHeader(RequestHeaders.ContentType, RequestHeaders.ApplicationJson);
        yield return request.SendWebRequest();

        UserData userDataFromServer = JsonUtility.FromJson<UserData>(request.downloadHandler.text);
        DebugPrint(userDataFromServer);
    }


    public IEnumerator Put(string url, UserData userData)
    {
        string json = JsonUtility.ToJson(userData);

        UnityWebRequest request = UnityWebRequest.Put(url, json);

        request.SetRequestHeader(RequestHeaders.ContentType, RequestHeaders.ApplicationJson);
        yield return request.SendWebRequest();

        UserData userDataFromServer = JsonUtility.FromJson<UserData>(request.downloadHandler.text);
        DebugPrint(userDataFromServer);
    }

    public IEnumerator Delete(string url)
    {
        UnityWebRequest request = UnityWebRequest.Delete(url);

        yield return request.SendWebRequest();

        Debug.LogError(request.responseCode);
    }

    public void DebugPrint(UserData userData)
    {
        Debug.Log("id: " + userData.id +
            ", name: " + userData.name +
            ", surname: " + userData.surname +
            ", age: " + userData.age);

    }
    public void DebugPrint(UsersData usersData)
    {
        foreach (var userData in usersData.usersData)
        {
            DebugPrint(userData);
        }
    }
}

