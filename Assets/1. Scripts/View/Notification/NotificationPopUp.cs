using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationPopUp : PopUp
{
    [SerializeField] private float _duration = 2f;
    [SerializeField] private NotificationController _notificationController;

    private void Start()
    {
        _notificationController.OnDisplay.AddListener(Show);
    }

    private void Show()
    {
        Open();
        StartCoroutine(WaitBeforeClose());
    }

    private IEnumerator WaitBeforeClose()
    {
        yield return new WaitForSeconds(_duration);
        Close();
    }
}
