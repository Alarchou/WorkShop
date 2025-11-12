using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int strikes = 0;
    public int strikesLimit = 3;

    public AudioSource sfxSource;
    public AudioClip buzzClip, successClip, failClip, placeClip;

    public void OnBoundaryTouched(Organ organ, BoundaryZone zone)
    {
        strikes++;
        Play(buzzClip);
        Haptics(0.3f, 0.2f); // simple placeholder haptique si tu ajoutes un wrapper

        if (strikes >= strikesLimit)
        {
            OnGameOver();
        }
        else
        {
            // Feedback visuel/sonore court
        }
    }

    public void OnWrongOrganPlaced(Organ organ)
    {
        Play(failClip);
        Haptics(0.4f, 0.2f);
    }

    public void OnOrganReplaced(Organ organ, OrganSocketValidator socket)
    {
        Play(placeClip);
        Haptics(0.2f, 0.1f);
        // TODO : compteur d’organes remplacés, progression, etc.
    }

    public void OnOldOrganDiscarded()
    {
        // Optionnel : feedback “ok”
    }

    void OnGameOver()
    {
        Play(failClip);
        // Afficher jumpscare, reload, etc.
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Play(AudioClip clip)
    {
        if (sfxSource && clip) sfxSource.PlayOneShot(clip);
    }

    void Haptics(float amplitude, float duration)
    {
        // Si tu utilises XRIT : cible les XRBaseController pour vibrer.
        // Laisse vide ici, ou fais un petit wrapper selon ton rig.
    }
}
