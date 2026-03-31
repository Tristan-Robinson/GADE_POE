using System.IO;
using UnityEngine;
using TMPro;

public class HintManager : MonoBehaviour
{
    public GameObject hintUI;
    public TextMeshProUGUI hintText;

    private DialogList dialogList;

    private void Awake()
    {
        LoadDialogs();
    }

    void LoadDialogs()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "dialog.json");

        if (!File.Exists(path))
        {
            Debug.LogError("dialog.json not found at " + path);
            return;
        }
        string json = File.ReadAllText(path);
        if (string.IsNullOrEmpty(json))
        {
            Debug.LogError("dialog.json is empty ");
            return;
        }

        dialogList = JsonUtility.FromJson<DialogList>("{\"dialogs\":" +json + "}");
        if (dialogList == null || dialogList.dialogs.Length == 0)
        {
            Debug.LogError("No dialogs found in JSON");
        }
        else
        {
            Debug.Log($"Loaded {dialogList.dialogs.Length} dialogs");
        }
    }

    public void ShowDialog(string id)
    {
        if (dialogList?.dialogs == null)
        {
            Debug.LogWarning("Dialog list not loaded");
            return;
        }
            

        DialogData entry = System.Array.Find(dialogList.dialogs, d => d.id == id);

        if (entry != null)
        {
            hintUI.SetActive(true);
            hintText.text = entry.message;
        }
        else
        {
             Debug.LogWarning("Dialog ID not found: " +  id);
        }
    }

    public void HideDialog()
    {
    hintUI.SetActive(false); 
    }
    
}