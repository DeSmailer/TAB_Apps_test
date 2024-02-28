using UnityEngine;

public abstract class RequestController : MonoBehaviour
{
    [SerializeField] protected RestAPI _restAPI;
    [SerializeField] protected NotificationController _notificationController;

}
