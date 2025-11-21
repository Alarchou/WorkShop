using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ScreamerEndToHopital : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // Lance la vidéo
        videoPlayer.Play();

        // Quand la vidéo est finie → retourne à la scène "hopital"
        videoPlayer.loopPointReached += (VideoPlayer vp) =>
        {
            SceneManager.LoadScene("hopital");
        };
    }
}
