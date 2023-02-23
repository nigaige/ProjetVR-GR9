using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateCanonWithHands : MonoBehaviour
{
    private XRGrabInteractable XRGrabInteractable;

    [SerializeField]
    private XRDirectInteractor _leftHand;
    [SerializeField]
    private XRDirectInteractor _rightHand;

    private GameObject _rightGrab;
    private GameObject _leftGrab;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable = GetComponent<XRGrabInteractable>();

        _rightGrab = transform.GetChild(1).GetComponent<GameObject>();
        _leftGrab = transform.GetChild(2).GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnPlayerGrabCanon()
    {
        
    }

    private void CheckCollidersGrabbed()
    {
        
         
    }


}
