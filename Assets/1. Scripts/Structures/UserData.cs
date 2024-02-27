using System;

[Serializable]
public struct UserData
{
    public int id;

    public string name;
    public string surname;
    public int age;
}

[Serializable]
public struct UsersData
{
    public UserData[] usersData;
}
