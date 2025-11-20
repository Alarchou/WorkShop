using System.Collections;
using UnityEngine;

public class DelayActivate : MonoBehaviour
{
    public GameObject objectToActivate;
    public AudioSource audioSource; 

    void Start()
    {
        StartCoroutine(EnableAfterDelay());
        Debug.Log("OK");
    }

    IEnumerator EnableAfterDelay()
    {
        yield return new WaitForSeconds(5f);

         
        if (audioSource != null)
            audioSource.Play();

        
        objectToActivate.SetActive(true);
    }
}
