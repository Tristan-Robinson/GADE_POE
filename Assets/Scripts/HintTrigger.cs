using UnityEngine;

public class HintTrigger : MonoBehaviour
{
    [TextArea]
    public string hintMessage;

    public HintManager hintSystem;

    public bool showOnlyOnce = true;
    public bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {

        if (hasTriggered && showOnlyOnce) 
            return;
        if (other.CompareTag("Player"))
        {
            hintSystem.ShowHint(hintMessage);
            hasTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hintSystem.HideHint();
        }
    }
}
