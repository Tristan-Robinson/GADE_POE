using UnityEngine;
using TMPro;
using System.Collections;

public class NotificationUI : MonoBehaviour
{
    public TextMeshProUGUI notificationtxt;

    public void ShowMessage(string message, float duration)
    {
        StartCoroutine(DisplayMessage(message, duration));
    }

    private IEnumerator DisplayMessage(string message, float duration)
    {
        notificationtxt.text = message;
        notificationtxt.gameObject.SetActive(true);

        yield return new WaitForSeconds(duration);

        notificationtxt.gameObject.SetActive(false);
    }
}
