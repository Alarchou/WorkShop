using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class WrongSocketDetector : MonoBehaviour
{
    public XRSocketInteractor socket;
    public XRGrabInteractable correctOrgan;
    public GameOverManager manager;
    private void Start()
    {
        socket.selectEntered.AddListener(OnPlaced);
    }

    private void OnPlaced(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform != correctOrgan.transform)
        {
            manager.Lose("Mauvais organe dans le socket");
        }
    }
}
