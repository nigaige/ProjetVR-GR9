using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;


public class ActivateTeleportation : MonoBehaviour
{
    public GameObject leftTeleportation;
    public GameObject rightTeleportation;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;
    


    bool AllowTP = true;




    // Start is called before the first frame update
    void Start(){

        
    }

    // Update is called once per frame
    void Update(){
        if (AllowTP){
            leftTeleportation.SetActive(leftActivate.action.ReadValue<float>()> 0.1f);
            rightTeleportation.SetActive(rightActivate.action.ReadValue<float>()> 0.1f);
        }   
    }

    void canTP(bool allow = true){
        AllowTP = allow;
    }






}
