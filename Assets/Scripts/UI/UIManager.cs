using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI gemText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateGems(int amount)
    {
        gemText.text = "Gems: " + amount;
    }
}
