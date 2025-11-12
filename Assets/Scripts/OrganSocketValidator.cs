using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor))]
public class OrganSocketValidator : MonoBehaviour
{
    public OrganType expectedType;

    UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;
    GameManager gm;

    void Awake()
    {
        socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();
        gm = FindObjectOfType<GameManager>();
        socket.selectEntered.AddListener(OnSelectEnter);
        socket.selectExited.AddListener(OnSelectExit);
    }

    void OnDestroy()
    {
        socket.selectEntered.RemoveListener(OnSelectEnter);
        socket.selectExited.RemoveListener(OnSelectExit);
    }

    void OnSelectEnter(SelectEnterEventArgs args)
    {
        var organ = args.interactableObject.transform.GetComponent<Organ>();
        if (organ == null) { Eject(args); return; }

        // doit être le bon type et neuf
        if (organ.type != expectedType || organ.isOld)
        {
            gm?.OnWrongOrganPlaced(organ);
            Eject(args);
            return;
        }

        // Succès : l’organe est posé
        organ.SetTransportState(false);
        gm?.OnOrganReplaced(organ, this);
        // Optionnel : verrouille le socket (empêche qu'on le reprenne)
        socket.enabled = false;
    }

    void OnSelectExit(SelectExitEventArgs args)
    {
        var organ = args.interactableObject.transform.GetComponent<Organ>();
        if (organ != null)
            organ.SetTransportState(true);
    }

    void Eject(SelectEnterEventArgs args)
    {
        // forcer l'éjection : le manager XR s’en charge
        var ixr = args.interactorObject as UnityEngine.XR.Interaction.Toolkit.Interactors.IXRSelectInteractor;
        if (ixr != null)
            socket.interactionManager.SelectExit(ixr, args.interactableObject);
    }
}
