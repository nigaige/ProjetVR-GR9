using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandGrabInteractable : XRGrabInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (interactorsSelecting.Count < 2)
        {
            trackRotation = false;
        }
        else
        {
            trackRotation= true;
        }

        if (multipleGrabTransformersCount < 2)
        {

        }

        base.OnSelectEntered(args);
    }
}
