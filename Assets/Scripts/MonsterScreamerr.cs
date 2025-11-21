using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterScreamerTrigger : MonoBehaviour
{
    [SerializeField] private string organTag = "Organ";            // Tag des organes
    [SerializeField] private string screamerSceneName = "ScreamerScene"; // Nom de la scène screamer

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(organTag))
        {
            // Quand un organ touche le monstre → on charge la scène Screamer
            SceneManager.LoadScene(screamerSceneName);
        }
    }
}
