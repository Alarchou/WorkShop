using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MonsterScreamer : MonoBehaviour
{
    public VideoPlayer screamerVideo;   // La vidéo du screamer
    public GameObject screamerCanvas;   // Le canvas/RawImage qui affiche la vidéo

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return; // évite double trigger

        hasTriggered = true;

        // Active l’affichage du screamer
        screamerCanvas.SetActive(true);

        // Lance la vidéo
        screamerVideo.Play();

        // Attend la fin de la vidéo → reload la scène
        screamerVideo.loopPointReached += OnScreamerEnd;
    }

    private void OnScreamerEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    [ContextMenu("Test Screamer")]
    private void Test()
    {
        // Méthode de test pour déclencher le screamer manuellement
        OnTriggerEnter(null);
    }
}