using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketSceneLoader : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;
    public string sceneName = "VideoFin";
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable requiredObject;

    private void Start()
    {
        socket.selectEntered.AddListener(OnObjectPlaced);
    }

    private void OnObjectPlaced(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform == requiredObject.transform)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
