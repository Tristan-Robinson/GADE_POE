using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(2);
    }
}
