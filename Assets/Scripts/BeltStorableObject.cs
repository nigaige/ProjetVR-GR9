using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltStorableObject : MonoBehaviour
{
    bool isStored = false;

    GameObject belt = null;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start(){
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other){
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == "Belt"){
            belt =  other.gameObject;
        } 
    }
    private void OnTriggerExit(Collider other){
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == "Belt"){
            belt = null;
        } 
    }


    void grabbed(){
        transform.parent = belt.transform;
        rb.isKinematic = false;
    }

    void drop(){
        //Stored
        if (belt != null){
            
            transform.parent = belt.transform;
            rb.isKinematic = true;
        }
    }



}
