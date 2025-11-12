using UnityEngine;

public class DiscardBin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var organ = other.GetComponentInParent<Organ>();
        if (organ != null && organ.isOld)
        {
            Destroy(organ.gameObject);
            FindObjectOfType<GameManager>()?.OnOldOrganDiscarded();
        }
    }
}
