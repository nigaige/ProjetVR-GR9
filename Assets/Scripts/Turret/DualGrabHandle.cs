using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class DualGrabHandle : XRGrabInteractable
{
    [SerializeField]
    private string _handTag;

    private XRGrabInteractable _interactable;

    private XRDirectInteractor _hand;

    private bool _isGrabbing;


    public bool IsGrabbing => _isGrabbing;


    // Start is called before the first frame update
    void Start()
    {
        _hand = GameObject.FindGameObjectWithTag(_handTag).GetComponent<XRDirectInteractor>();
        _interactable = GetComponent<XRGrabInteractable>();
    }


    //public void CheckHandSelect()
    //{
    //    if (_hand == null ) return;

    //    //if (_interactable.firstInteractorSelecting == _hand)
    //    //{
    //    //    print(_hand.gameObject.ToString());
    //    //}

    //    if (_hand.IsSelecting(_interactable))
    //    {
    //        _isGrabbing = true;
    //    }
        
            

       
    //}

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject == _hand as IXRSelectInteractor)
        {
            _isGrabbing = true;
        }
        else
        {
            _isGrabbing = false;
        }

        print(_hand);

        print(_isGrabbing);
        base.OnSelectEntered(args);
    }


    protected override void OnSelectExited(SelectExitEventArgs args)
    {

        _isGrabbing = false;

        print(_isGrabbing);
        base.OnSelectExited(args);
    }
}
