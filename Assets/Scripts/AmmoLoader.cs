using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoLoader : MonoBehaviour
{

    [SerializeField]
    private FireMissileOnActivate gun = null;


    private void OnTriggerEnter(Collider other){
        gun.getAmmo(other.GetComponent<Ammo>().ammoCount);
        Debug.Log(other.GetComponent<Ammo>().ammoCount);
        other.GetComponent<Ammo>().hasBeenLoaded();
    }

}
