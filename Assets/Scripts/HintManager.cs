using UnityEngine;
using TMPro;

public class HintManager : MonoBehaviour
{
    public GameObject hintUI;
    public TextMeshProUGUI hintText;

    public void ShowHint(string message)
    {
        hintUI.SetActive(true);
        hintText.text = message;
    }

    public void HideHint()
    {
    hintUI.SetActive(false); 
    }
    
}