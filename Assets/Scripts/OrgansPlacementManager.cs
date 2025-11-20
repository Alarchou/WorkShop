using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class OrgansPlacementManager : MonoBehaviour
{
    [Header("Sockets")]
    public XRSocketInteractor heartSocket;
    public XRSocketInteractor lungSocket;
    public XRSocketInteractor stomachSocket;

    [Header("Correct Objects")]
    public XRGrabInteractable heartObject;
    public XRGrabInteractable lungObject;
    public XRGrabInteractable stomachObject;

    [Header("Next Scene")]
    public string sceneName = "VideoFin";

    private void Update()
    {
        // Vérifie en permanence si les 3 sont bien placés
        if (AreAllCorrectlyPlaced())
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private bool AreAllCorrectlyPlaced()
    {
        return CheckSocket(heartSocket, heartObject) &&
               CheckSocket(lungSocket, lungObject) &&
               CheckSocket(stomachSocket, stomachObject);
    }

    private bool CheckSocket(XRSocketInteractor socket, XRGrabInteractable required)
    {
        // Aucun objet dans le socket → faux
        if (socket.interactablesSelected.Count == 0)
            return false;

        // L'objet actuellement contenu dans ce socket
        IXRSelectInteractable current = socket.interactablesSelected[0];

        // C'est le bon si ils matchent
        return current.transform.gameObject == required.gameObject;
    }
}