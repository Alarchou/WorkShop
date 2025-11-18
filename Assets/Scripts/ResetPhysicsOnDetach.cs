using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ResetPhysicsOnDetach : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab;
    private Rigidbody rb;

    private void Awake()
    {
        grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        grab.selectExited.AddListener(OnReleased);
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
