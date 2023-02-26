using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateCanonWithHands : MonoBehaviour
{
    private XRGrabInteractable XRGI;

    private XRDirectInteractor _handLeft;
    private XRDirectInteractor _handRight;

    private DualGrabHandle _rightGrab;
    private DualGrabHandle _leftGrab;

    // Start is called before the first frame update
    void Start()
    {
        XRGI = GetComponent<XRGrabInteractable>();

        _handLeft = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<XRDirectInteractor>();
        _handRight = GameObject.FindGameObjectWithTag("RightHand").GetComponent<XRDirectInteractor>();

        _rightGrab = transform.GetChild(1).GetComponent<DualGrabHandle>();
        _leftGrab = transform.GetChild(2).GetComponent<DualGrabHandle>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerGrabsCanon();

        
    }

    private void CheckPlayerGrabsCanon()
    {
        if (_rightGrab.IsGrabbing && _leftGrab.IsGrabbing) 
        { 
            CalculateAngle();
        }
    }


    private void CalculateAngle() 
    { 
        Vector3 GrabMiddleDist = (_rightGrab.transform.position - _leftGrab.transform.position) / 2;

        Vector3 middle = (_leftGrab.transform.position + GrabMiddleDist).normalized;

        var dist = Vector3.Angle(middle, transform.position);

        print(dist);
    }




}
