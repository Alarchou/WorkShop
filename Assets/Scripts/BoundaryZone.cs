using UnityEngine;

public class BoundaryZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var organ = other.GetComponentInParent<Organ>();
        if (organ != null && organ.isBeingTransported)
        {
            FindObjectOfType<GameManager>()?.OnBoundaryTouched(organ, this);
        }
    }
}
