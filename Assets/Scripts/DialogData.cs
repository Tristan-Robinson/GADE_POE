using UnityEngine;

[System.Serializable]
public class DialogData
{
    public string id;
    public string message;
}

[System.Serializable]
public class DialogList
{
    public DialogData[] dialogs;
}
