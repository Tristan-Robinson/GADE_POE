using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndgameManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(EndLevel());
        }
    }

    IEnumerator EndLevel()
    {
        SFXManager.Instance.PlaySound("Victory");

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(0);
    }
}
