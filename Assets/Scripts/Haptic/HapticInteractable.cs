using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;



public class HapticInteractable : MonoBehaviour
{


    XRBaseController _controller;

    [SerializeField]
    [Range(0f, 1f)]
    private float _intensity;

    [SerializeField]
    private float _duration;
    // Start is called before the first frame update


    void Start()
    {
        XRBaseInteractable interactable = GetComponentInParent<XRBaseInteractable>();

        interactable.activated.AddListener(TriggerHapticEvent);
    }


    public void TriggerHapticEvent(BaseInteractionEventArgs eventArgs)
    {
        if (eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
            _controller = controllerInteractor.xrController;
    }

    public void TriggerHaptic()
    {

        if (_intensity > 0f)
        {
            _controller.SendHapticImpulse(_duration, _intensity);
        }
    }


}
