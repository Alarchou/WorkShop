using UnityEngine;

public class OrganFallDetector : MonoBehaviour
{
    public GameOverManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sol"))
        {
            manager.Lose("Organe tombé au sol");
        }
    }


}
