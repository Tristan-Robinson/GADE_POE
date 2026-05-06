using UnityEngine;
using UnityEngine.SceneManagement;

public class EndgameManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0);
    }
}
