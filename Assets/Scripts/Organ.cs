using UnityEngine;

public class Organ : MonoBehaviour
{
    public OrganType type;
    [Tooltip("Vrai s'il s'agit d'un organe usé à remplacer.")]
    public bool isOld = true;

    [HideInInspector] public bool isBeingTransported; // vrai quand pas dans un socket

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetTransportState(bool transporting)
    {
        isBeingTransported = transporting;
        // Un petit damping pour le “feeling”
        rb.linearDamping = transporting ? 2f : 0f;
        rb.angularDamping = transporting ? 2f : 0.05f;
    }
}
