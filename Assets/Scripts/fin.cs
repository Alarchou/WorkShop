using UnityEngine;
using UnityEngine.Video;

public class ExitAfterVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = FindObjectOfType<VideoPlayer>();
        }

        if (videoPlayer != null)
        {
            // Quand la vidéo se termine → on appelle OnVideoFinished
            videoPlayer.loopPointReached += OnVideoFinished;
        }
        else
        {
            Debug.LogError("Aucun VideoPlayer trouvé pour ExitAfterVideo.");
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("Vidéo terminée → quitter le jeu");

        // Quitter le build
        Application.Quit();

#if UNITY_EDITOR
        // Pour tester dans l'éditeur
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
