using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour{
    [field:SerializeField] public int ammoCount { get; private set; } = 1;

    public void hasBeenLoaded(){
        Destroy(gameObject);
    }
}
