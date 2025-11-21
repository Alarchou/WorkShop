using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Collections;

public class ScreamerEndToHopital : MonoBehaviour
{
    public VideoPlayer videoPlayer;    // Ton Video Player
    public AudioSource screamerSound;  // Ton AudioSource avec le son
    public float soundDelay = 0.2f;      // Délai avant le son

    private void Start()
    {
        // Sécurités : si on a oublié d'assigner dans l'inspector
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        if (screamerSound == null)
        {
            screamerSound = GetComponent<AudioSource>();
        }

        StartCoroutine(PlayScreamer());
    }

    private IEnumerator PlayScreamer()
    {
        if (videoPlayer == null)
        {
            Debug.LogError("[Screamer] Pas de VideoPlayer trouvé !");
            yield break;
        }

        // Préparer la vidéo
        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        // On abonne la fin de vidéo AVANT de lancer
        videoPlayer.loopPointReached += OnVideoFinished;

        // Lance la vidéo
        videoPlayer.Play();

        // Attendre soundDelay secondes avant le son
        yield return new WaitForSeconds(soundDelay);

        if (screamerSound != null)
        {
            screamerSound.Play();
        }
        else
        {
            Debug.LogWarning("[Screamer] Pas d'AudioSource pour le son de screamer !");
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene("hopital");
    }
}
