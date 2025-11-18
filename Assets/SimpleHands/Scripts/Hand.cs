using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

/// <summary>
/// Class that handles hand animation based on input actions
/// </summary>
public class Hand : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] NearFarInteractor nearFarInteractor;
    [SerializeField] InputActionReference thumbAction;
    [SerializeField] InputActionReference indexAction;
    [SerializeField] InputActionReference gripAction;

    [SerializeField, Tooltip("Smooth applied to layer weights transitions")] float smoothTime = 0.05f;

    private int thumbHash = Animator.StringToHash("Thumb");
    private int indexHash = Animator.StringToHash("Index");
    private int gripHash = Animator.StringToHash("Grip");
    private int poseHash = Animator.StringToHash("PoseId");

    private float layerWeightTarget = 1f;

    private void OnEnable()
    {
        nearFarInteractor.selectEntered.AddListener(OnSelectEntered);
        nearFarInteractor.selectExited.AddListener(OnSelectExited);
    }

    private void OnDisable()
    {
        nearFarInteractor.selectEntered.RemoveListener(OnSelectEntered);
        nearFarInteractor.selectExited.RemoveListener(OnSelectExited);
    }

    private void OnSelectExited(SelectExitEventArgs interactionInfos)
    {
        ReleasePose();
    }

    private void OnSelectEntered(SelectEnterEventArgs interactionInfos)
    {

        Debug.Log("Select Entered on " + interactionInfos.interactableObject.transform.gameObject.name);

        if (interactionInfos.interactableObject.transform.gameObject.TryGetComponent(out InteractionHandPose handPose))
        {
            SetHandPose(handPose.PoseId);
            Debug.Log("Hand Pose set to " + handPose.PoseId);
        }

        else
        {
            Debug.Log("No Hand Pose defined on this object");
        }
    }

    private void Update()
    {
        UpdateHandInputs();
        UpdateWeightTarget();
    }

    private void UpdateHandInputs()
    {
        if(animator.isInitialized == false)
        {
            Debug.LogWarning("Animator not initialized yet.", animator);
            return;
        }

        float thumbValue = thumbAction.action.ReadValue<float>();
        float indexValue = indexAction.action.ReadValue<float>();
        float gripValue = gripAction.action.ReadValue<float>();

        animator.SetBool(thumbHash, thumbValue > 0.5f);
        animator.SetFloat(indexHash, indexValue);
        animator.SetFloat(gripHash, gripValue);
    }

    public void SetHandPose(int id)
    {
        animator.SetInteger(poseHash, id);
    }

    public void ReleasePose()
    {
        animator.SetInteger(poseHash, 0);
    }

    private void UpdateWeightTarget()
    {

        if(nearFarInteractor.isSelectActive)
        {
            layerWeightTarget = Mathf.SmoothDamp(layerWeightTarget, 0, ref layerWeightTarget, smoothTime);
        }

        else
        {
            layerWeightTarget = Mathf.SmoothDamp(layerWeightTarget, 1, ref layerWeightTarget, smoothTime);
        }

        for (int i = 1; i < 4; i++)
        {
            animator.SetLayerWeight(i, Mathf.Clamp01(layerWeightTarget));
        }
    }
}
