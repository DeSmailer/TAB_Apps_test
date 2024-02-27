using UnityEngine;

public class InfoButton : MonoBehaviour
{
    [SerializeField] private UserData _userData;

    public UserData UserData => _userData;

    public void Initialize(UserData userData)
    {
        _userData = userData;
    }
}
